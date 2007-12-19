using System;
using System.Collections.Generic;
using System.Text;
using EVEMon.Common;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace EVEPOSMon
{
    public class Fuel
    {
        [XmlElement]
        public string typeId;

        [XmlElement]
        public string quantity;

        [XmlElement]
        public string quantityUsedPerHour;

        [XmlElement]
        public TimeSpan timeRemaining;

        [XmlElement]
        public string name;

        [XmlElement]
        public string volume;
    }

    public class CompareFuelByTimeLeft : IComparer<Fuel>
    {
        public int Compare(Fuel x, Fuel y)
        {
            if (x.timeRemaining > y.timeRemaining)
            {
                return -1;
            }
            if (x.timeRemaining < y.timeRemaining)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
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

        [XmlElement]
        public string nickname;

        [XmlElement]
        public double totalFuelVolume;

        [XmlElement]
        public double totalStrontiumVolume;

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
            XmlDocument xdoc = EveSession.GetStarbaseList("","",""); ;
            Settings settings = Settings.GetInstance();
            XmlNode error = xdoc.DocumentElement.SelectSingleNode("descendant::error");
            if (error != null)
            {
                throw new InvalidDataException(error.InnerText);
            }
            else
            {
                List<Starbase> newStarbasesList = new List<Starbase>();
                DateTime cachedUntil = EveSession.GetCacheExpiryUTC(xdoc);
                XmlNodeList starbases = xdoc.DocumentElement.SelectNodes("descendant::rowset/row");
                foreach (XmlNode starbaseNode in starbases)
                {
                    Starbase starbase = new Starbase();
                    starbase.LoadFromListApiXml(starbaseNode, cachedUntil);
                    newStarbasesList.Add(starbase);
                }

                // If we had starbases checked make sure they stay checked
                foreach (Starbase oldStarbase in settings.availableStarBases)
                {
                    foreach (Starbase newStarbase in newStarbasesList)
                    {
                        if (oldStarbase.itemId == newStarbase.itemId)
                        {
                            newStarbase.monitored = oldStarbase.monitored;
                        }
                    }
                }

                settings.availableStarBases = newStarbasesList;
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

        public void LoadStarbaseDetailsFromApi()
        {
            // Don't send a request to the api unless we're expired
            if (DateTime.Now < this.cachedUntil && this.lastDownloaded != DateTime.MinValue)
            {
                return;
            }

            XmlDocument detailsXmlDoc = EveSession.GetStarbaseDetail("","","", this.itemId);

            XmlNode error = detailsXmlDoc.DocumentElement.SelectSingleNode("descendant::error");
            if (error != null)
            {
                throw new InvalidDataException(error.InnerText);
            }
            else
            {
                LoadDetailsFromXml(detailsXmlDoc);
            }
        }

        public void LoadDetailsFromXml(System.Xml.XmlDocument detailsXmlDoc)
        {
            this.cachedUntil = EveSession.GetCacheExpiryUTC(detailsXmlDoc);
            lastDownloaded = DateTime.Now;
            usageFlags = detailsXmlDoc.GetElementsByTagName("usageFlags")[0].InnerText;
            deployFlags = detailsXmlDoc.GetElementsByTagName("deployFlags")[0].InnerText;
            allowAllianceMembers = detailsXmlDoc.GetElementsByTagName("allowAllianceMembers")[0].InnerText;
            allowCorporationMembers = detailsXmlDoc.GetElementsByTagName("allowCorporationMembers")[0].InnerText;
            claimSovereignty = detailsXmlDoc.GetElementsByTagName("claimSovereignty")[0].InnerText;

            XmlAttributeCollection attrs;

            attrs = detailsXmlDoc.GetElementsByTagName("onStandingDrop")[0].Attributes;
            onStandingDrop.enabled = attrs["enabled"].InnerText;
            onStandingDrop.standing = attrs["standing"].InnerText;

            attrs = detailsXmlDoc.GetElementsByTagName("onStatusDrop")[0].Attributes;
            onStatusDrop.enabled = attrs["enabled"].InnerText;
            onStatusDrop.standing = attrs["standing"].InnerText;

            attrs = detailsXmlDoc.GetElementsByTagName("onAggression")[0].Attributes;
            onAgression.enabled = attrs["enabled"].InnerText;

            attrs = detailsXmlDoc.GetElementsByTagName("onCorporationWar")[0].Attributes;
            onCorporationWar.enabled = attrs["enabled"].InnerText;

            FuelList.Clear();
            XmlNodeList fuelNodeList = detailsXmlDoc.DocumentElement.SelectNodes("descendant::rowset/row");
            foreach (XmlNode fuelNode in fuelNodeList)
            {
                XmlAttributeCollection atts = fuelNode.Attributes;
                Fuel fuel = new Fuel();
                fuel.typeId = atts["typeID"].InnerText;
                fuel.quantity = atts["quantity"].InnerText;
                this.FuelList.Add(fuel);
            }
        }

        public static void SerializeStarbasesToFile(string filename, List<Starbase> starbaseList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Starbase>));
            using (Stream s = new FileStream(filename, FileMode.Create))
            {
                serializer.Serialize(s, starbaseList);
            }
        }

    }
}
