using System;
using System.Collections.Generic;
using System.Text;
using EVEMon.Common;
using System.Xml;
using System.IO;

namespace EVEPOSMon
{
    public class Fuel
    {
        public string typeId;
        public string quantity;
    }

    public class Starbase
    {
        public string itemId;
        public string typeId;
        public string locationId;
        public string moonId;
        public string state;
        public DateTime stateTimestamp;
        public DateTime onlineTimeStamp;
        public DateTime cachedUntil;
        public DateTime lastDownloaded;

        #region map data

        private String solarsystem;
        private String constellation;
        private String region;
        private String security;

        #endregion

        #region General Settings

        public string usageFlags;
        public string deployFlags;
        public string allowCorporationMembers;
        public string allowAllianceMembers;
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

        public OnStandingDrop onStandingDrop = new OnStandingDrop();
        public OnStatusDrop onStatusDrop = new OnStatusDrop();
        public OnAgression onAgression = new OnAgression();
        public OnCorporationWar onCorporationWar = new OnCorporationWar();

        #endregion

        public List<Fuel> FuelList = new List<Fuel>();
        private Settings m_settings = Settings.GetInstance();

        public override string ToString()
        {
            MapSystem ms = m_settings.mapData.GetSystemInfo(locationId);
            ControlTower ct = m_settings.controlTowerTypes.GetTowerInfo(typeId);
            return ct.typeName + " -- " + ms.systemName;
        }

        internal void setValues(System.Xml.XmlAttributeCollection atts)
        {
            // Taken from SelectStarbases.cs->btnLoadStations_Click() to internalize starbase functions
            itemId = atts["itemID"].InnerText;
            typeId = atts["typeID"].InnerText;
            locationId = atts["locationID"].InnerText;
            moonId = atts["moonID"].InnerText;
            state = atts["state"].InnerText;
            stateTimestamp = EveSession.ConvertCCPTimeStringToDateTime(atts["stateTimestamp"].InnerText);
            onlineTimeStamp = EveSession.ConvertCCPTimeStringToDateTime(atts["onlineTimestamp"].InnerText);
            setMapInformation();
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

        private void setMapInformation()
        {
            try
            {
                // Load the file into memory
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(@"./data/mapData.xml");

                string starbaseError;
                DateTime cachedUntil;

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
                    
                    XmlNodeList systemNodeList = xdoc.GetElementsByTagName("system");

                    foreach (XmlNode systemNode in systemNodeList)
                    {
                        if (systemNode.FirstChild.InnerText == (this.locationId))
                        {
                            this.solarsystem = systemNode.ChildNodes.Item(1).InnerText;
                            this.region = systemNode.ChildNodes.Item(4).InnerText;
                            this.constellation = systemNode.ChildNodes.Item(3).InnerText;
                            this.security = systemNode.ChildNodes.Item(2).InnerText;
                            return; // once you've found the node with the information there is noneed to go any further in the search.
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
            }
        }
        public String getSolarSystem()
        {
            return this.solarsystem;
        }
        public String getRegion()
        {
            return this.region;
        }
        public String getSecurity()
        {
            return this.security;
        }
        public String getConstellation()
        {
            return this.constellation;
        }
        public String getLocationID()
        {
            return this.locationId;
        }
    }
}
