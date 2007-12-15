using System;
using System.Collections.Generic;
using System.Text;
using EVEMon.Common;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using EVEMon.Common;

namespace EVEPOSMon
{
    public class Fuel
    {
        [XmlElement]
        public string typeId;

        [XmlElement]
        public string quantity;
    }

    public class Starbase
    {
        [XmlElement]
        public string itemId;

        [XmlElement]
        public string typeId;

        [XmlElement]
        public string locationId;

        [XmlElement]
        public string moonId;

        [XmlElement]
        public string state;

        [XmlElement]
        public DateTime stateTimestamp;

        [XmlElement]
        public DateTime onlineTimeStamp;

        [XmlElement]
        public DateTime cachedUntil;

        [XmlElement]
        public DateTime lastDownloaded;

        [XmlElement]
        public bool monitored;

        #region map data

        private MapSystem starbaseSystem;
        public MapSystem StarbaseSystem
        {
            get
            {
                if (starbaseSystem == null)
                {
                    this.starbaseSystem = m_settings.mapData.GetSystemInfo(this.locationId);
                }
                return this.starbaseSystem;
            }
        }

        private ControlTower tower;
        public ControlTower Tower
        {
            get
            {
                if (tower == null)
                {
                    tower = m_settings.controlTowerTypes.GetTowerInfo(this.typeId);
                }
                return tower;
            }
        }

        private MoonInfo moon;
        public MoonInfo Moon
        {
            get
            {
                if (moon == null)
                {
                    moon = m_settings.moonData.GetMoonInfo(this.moonId);
                }
                return moon;
            }
        }

        #endregion

        #region General Settings

        [XmlElement]
        public string usageFlags;

        [XmlElement]
        public string deployFlags;

        [XmlElement]
        public string allowCorporationMembers;

        [XmlElement]
        public string allowAllianceMembers;

        [XmlElement]
        public string claimSovereignty;

        #endregion

        #region Combat Settings

        public class OnStandingDrop
        {
            public string enabled;
            public string standing;
        }

        public class OnStatusDrop
        {
            public string enabled;
            public string standing;
        }

        public class OnAgression
        {
            public string enabled;
        }

        public class OnCorporationWar
        {
            public string enabled;
        }

        [XmlElement]
        public OnStandingDrop onStandingDrop = new OnStandingDrop();

        [XmlElement]
        public OnStatusDrop onStatusDrop = new OnStatusDrop();

        [XmlElement]
        public OnAgression onAgression = new OnAgression();

        [XmlElement]
        public OnCorporationWar onCorporationWar = new OnCorporationWar();

        #endregion

        [XmlArray("fuelList")]
        public List<Fuel> FuelList = new List<Fuel>();

        private Settings m_settings = Settings.GetInstance();

        public override string ToString()
        {
            //MapSystem ms = m_settings.mapData.GetSystemInfo(locationId);
            ControlTower ct = m_settings.controlTowerTypes.GetTowerInfo(typeId);
            return ct.typeName + " -- " + StarbaseSystem.systemName + " -- " + StarbaseSystem.security + " -- " + ct.description;
        }

        /// <summary>
        /// Get the starbase list from the API, add the starbases to the availableStarbases list in Settings
        /// </summary>
        public static void LoadStarbaseListFromApi()
        {
            XmlDocument xdoc = EVEMonWebRequest.LoadXml(@"http://www.exa-nation.com/corp/StarbaseList.xml.aspx");
            Settings settings = Settings.GetInstance();
            XmlNode error = xdoc.DocumentElement.SelectSingleNode("descendant::error");
            // If a read error occured, exit
            if (error != null)
            {
                throw new InvalidDataException(error.InnerText);
            }
            // Process xml file 
            else
            {
                // For each starbase in the list create an object and place it on the master(m) starbase list
                DateTime cachedUntil = EveSession.GetCacheExpiryUTC(xdoc);
                XmlNodeList starbases = xdoc.DocumentElement.SelectNodes("descendant::rowset/row");
                foreach (XmlNode starbaseNode in starbases)
                {
                    Starbase starbase = new Starbase();
                    starbase.LoadFromListApiXml(starbaseNode, cachedUntil);
                    settings.availableStarBases.Add(starbase);
                }
            }
        }

        public void LoadFromListApiXml(XmlNode starbaseNode, DateTime cachedUntil)
        {
            XmlAttributeCollection attrs = starbaseNode.Attributes;
            this.itemId = attrs["itemID"].InnerText;
            this.typeId = attrs["typeID"].InnerText;
            this.locationId = attrs["locationID"].InnerText;
            this.moonId = attrs["moonID"].InnerText;
            this.state = attrs["state"].InnerText;
            this.stateTimestamp = EveSession.ConvertCCPTimeStringToDateTime(attrs["stateTimestamp"].InnerText);
            this.onlineTimeStamp = EveSession.ConvertCCPTimeStringToDateTime(attrs["onlineTimestamp"].InnerText);
            this.cachedUntil = cachedUntil;
        }

        internal void setDetails(String loc)
        {
            XmlDocument xdoc = EVEMonWebRequest.LoadXml(@loc + this.itemId);

            string starbaseError;

            XmlNode error = xdoc.DocumentElement.SelectSingleNode("descendant::error");
            // If a read error occured, exit
            if (error != null)
            {
                starbaseError = error.InnerText;
                throw new InvalidDataException(starbaseError);
            }
            else
            {
                cachedUntil = EveSession.GetCacheExpiryUTC(xdoc);
                /*  ****** Code moved to setDetails() ******   */
                setDetails(xdoc);

                XmlNodeList fuelNodeList = xdoc.DocumentElement.SelectNodes("descendant::rowset/row");
                // Clear any old data from the list before adding new information
                FuelList.Clear();
                foreach (XmlNode fuelNode in fuelNodeList)
                {
                    XmlAttributeCollection atts = fuelNode.Attributes;
                    Fuel fuel = new Fuel();
                    fuel.typeId = atts["typeID"].InnerText;
                    fuel.quantity = atts["quantity"].InnerText;
                    this.FuelList.Add(fuel);
                }
            }
        }
        internal void setDetails(System.Xml.XmlDocument xdoc)
        {
            lastDownloaded = DateTime.Now;
            usageFlags = xdoc.GetElementsByTagName("usageFlags")[0].InnerText;
            deployFlags = xdoc.GetElementsByTagName("deployFlags")[0].InnerText;
            allowAllianceMembers = xdoc.GetElementsByTagName("allowAllianceMembers")[0].InnerText;
            allowCorporationMembers = xdoc.GetElementsByTagName("allowCorporationMembers")[0].InnerText;
            claimSovereignty = xdoc.GetElementsByTagName("claimSovereignty")[0].InnerText;

            XmlAttributeCollection attrs;

            attrs = xdoc.GetElementsByTagName("onStandingDrop")[0].Attributes;
            onStandingDrop.enabled = attrs["enabled"].InnerText;
            onStandingDrop.standing = attrs["standing"].InnerText;

            attrs = xdoc.GetElementsByTagName("onStatusDrop")[0].Attributes;
            onStatusDrop.enabled = attrs["enabled"].InnerText;
            onStatusDrop.standing = attrs["standing"].InnerText;

            attrs = xdoc.GetElementsByTagName("onAggression")[0].Attributes;
            onAgression.enabled = attrs["enabled"].InnerText;


            attrs = xdoc.GetElementsByTagName("onCorporationWar")[0].Attributes;
            onCorporationWar.enabled = attrs["enabled"].InnerText;
        }

    }
}
