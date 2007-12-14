using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using EVEMon.Common;

namespace EVEPOSMon
{
    class SerializableStarbase
    {
        private Settings m_settings = Settings.GetInstance();

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

        [XmlArray]
        public List<Fuel> FuelList = new List<Fuel>();
    }
}
