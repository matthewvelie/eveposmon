using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace eveposmon.StaticData
{
    public class SystemFactions
    {
        private static Hashtable table = new Hashtable();

        public static void LoadFromFile(string file)
        {
            using (FileStream s = new FileStream(file, FileMode.Open))
            using (GZipStream gz = new GZipStream(s, CompressionMode.Decompress))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(gz);

                foreach (XmlNode node in doc.SelectNodes("solarSystemFactions/row"))
                {
                    SolarSystem solarSystem = new SolarSystem();
                    solarSystem.Id = Convert.ToInt32(node.Attributes["solarSystemID"].InnerText);
                    solarSystem.FactionId = Convert.ToInt32(node.Attributes["factionID"].InnerText);

                    table.Add(solarSystem.Id, solarSystem);
                }
            }
        }

        public static SolarSystem GetBySolarSystemId(int solarSystemId)
        {
            if (table.Contains(solarSystemId))
            {
                return table[solarSystemId] as SolarSystem;
            }

            return null;
        }

        public class SolarSystem
        {
            public int Id;
            public int FactionId;
        }
    }
}