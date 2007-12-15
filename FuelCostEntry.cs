using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Text;
using EVEMon.Common;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace EVEPOSMon
{
    public class FuelCostEntry
    {
        [XmlElement] 
        public string typeId; 
 
        [XmlElement] 
        public double costPerUnit;

        [XmlElement]
        public DateTime lastUpdated;

        private Settings m_settings = Settings.GetInstance();


        public static void SerializeFuelToFile(string filename, List<FuelCostEntry> fuelList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<FuelCostEntry>));
            using (Stream s = new FileStream("fuelCost.xml", FileMode.Create))
            {
                serializer.Serialize(s, fuelList);
            }
        }
    }
}
