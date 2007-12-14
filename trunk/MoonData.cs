using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EVEPOSMon
{
    public class Moon
    {
        public string moonId;
        public string moonName;
    }

    public class MoonData
    {
        public Hashtable Moons = new Hashtable();

        public static MoonData Load(string filename)
        {
            using (Stream s = new FileStream(filename, FileMode.Open))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(s);
                MoonData moonData = new MoonData();
                XmlNodeList rowsNodeList = doc.GetElementsByTagName("row");
                foreach (XmlNode r in rowsNodeList)
                {
                    Moon moon = new Moon();
                    moon.moonId = r.ChildNodes[0].InnerText;
                    moon.moonName = r.ChildNodes[1].InnerText;
                    moonData.Moons.Add(moon.moonId, moon);
                }

                return moonData;
            }
        }

        public Moon GetMoonInfo(string moonId)
        {
            if (Moons.ContainsKey(moonId))
            {
                return Moons[moonId] as Moon;
            }
            return null;
        }
    }
}
