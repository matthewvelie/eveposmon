using System;
using System.Collections.Generic;
using System.Text;

namespace EVEPOSMon
{
    class Starbase
    {
        public string itemId;
        public string typeId;
        public string locationId;
        public string moonId;
        public string state;
        public DateTime stateTimestamp;
        public DateTime onlineTimeStamp;

        public override string ToString()
        {
            return itemId;
        }
    }
}
