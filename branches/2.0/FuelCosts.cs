using System;
using System.Collections.Generic;
using System.Text;
using EVEMon.Common;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace EVEPOSMon
{
    public class FuelCosts
    {
        #region Member Definition
        [XmlElement]
        private String mechparts = "0";     //Mechanical Parts

        public String MechanicalPartsPricePer
        {
            get { return mechparts; }
            set { mechparts = value;}
        }

        [XmlElement]
        private String coolant = "0";             //Coolant

        public String CoolantPricePer
        {
            get { return coolant; }
            set { coolant = value; }
        }
        
        [XmlElement]
        private String robotics = "0";            //Robotics

        public String RoboticsPricePer
        {
            get { return robotics; }
            set { robotics = value; }
        }

        [XmlElement]
        private String oxygen = "0";              //Oxygen

        public String OxygenPricePer
        {
            get { return oxygen; }
            set { oxygen = value; }
        }

        [XmlElement]
        private String oxyisotopes = "0";      //Oxygen Isotopes

        public String OxygenIsotopesPricePer
        {
            get { return oxyisotopes; }
            set { oxyisotopes = value; }
        }

        [XmlElement]
        private String heavywater = "0";          //Heavy Water

        public String HeavyWaterPricePer
        {
            get { return heavywater; }
            set { heavywater = value; }
        }

        [XmlElement]
        private String liqozone = "0";         //Liquid Ozone

        public String LiquidOzonePricePer
        {
            get { return liqozone; }
            set { liqozone = value; }
        }

        [XmlElement]
        private String enruranium = "0";     //Enriched Uranium

        public String EnrichedUraniumPricePer
        {
            get { return enruranium; }
            set { enruranium = value; }
        }
        
        [XmlElement]
        private String nitisotopes = "0";    //Nitrogen Isotopes

        public String NitrogenIsotopesPricePer
        {
            get { return nitisotopes; }
            set { nitisotopes = value; }
        }

        [XmlElement]
        private String helisotopes = "0";      //Helium Isotopes

        public String HeliumIsotopesPricePer
        {
            get { return helisotopes; }
            set { helisotopes = value; }
        }

        [XmlElement]
        private String hydisotopes = "0";    //Hydrogen Isotopes

        public String HydrogenIsotopesPricePer
        {
            get { return hydisotopes; }
            set { hydisotopes = value; }
        }

        [XmlElement]
        private String stront = "0";           //Strontium Clatherates

        public String StrontiumPricePer
        {
            get { return stront; }
            set { stront = value; }
        }

        private DateTime lastupdated = DateTime.MinValue;

        public DateTime LastUpdated
        {
            get { return lastupdated; }
            set { lastupdated = value; }
        }
        #endregion


        public static void SerializeFuelToFile(string filename, FuelCosts fuelcost)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(FuelCosts));
            using (Stream s = new FileStream(filename, FileMode.Create))
            {
                serializer.Serialize(s, fuelcost);
            }
        }

    }
}
