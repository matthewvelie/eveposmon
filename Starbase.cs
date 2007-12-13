using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
