using System;
using System.Collections.Generic;
using System.Text;
using EVEMon.Common;

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

        public override string ToString()
        {
            return itemId;
        }

        internal object getStationDetails()
        {
            return null;
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
        }
    }
}
