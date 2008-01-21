using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EVEPOSMon
{
    public class MoonInfo
    {
        public string moonId;
        public string moonName;
    }

    public class MoonData
    {
        public Hashtable Moons = new Hashtable(232767);

        public static MoonData Load(Stream s)
        {
            XmlReader reader = XmlReader.Create(s);
            reader.ReadStartElement("moons");
            MoonData moonData = new MoonData();

            while (reader.Read())
            {
                if (reader.AttributeCount == 2)
                {
                    MoonInfo mi = new MoonInfo();
                    mi.moonId = reader.GetAttribute("moonId");
                    mi.moonName = reader.GetAttribute("moonName");
                    moonData.Moons.Add(mi.moonId, mi);
                }
            }

            return moonData;
        }

        public MoonInfo GetMoonInfo(string moonId)
        {
            if (Moons.ContainsKey(moonId))
            {
                return Moons[moonId] as MoonInfo;
            }
            return null;
        }
    }
}
