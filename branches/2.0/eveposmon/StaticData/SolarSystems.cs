using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace eveposmon.StaticData
{
    public class SolarSystems
    {
        public static Hashtable table = new Hashtable(5382);

        public static void LoadFromFile(string file)
        {
            using (FileStream s = new FileStream(file, FileMode.Open))
            using (GZipStream gz = new GZipStream(s, CompressionMode.Decompress))
            {
                XmlReader reader = XmlReader.Create(gz);
                reader.ReadStartElement("solarSystem");

                while (reader.Read())
                {
                    if (reader.Name == "system")
                    {
                        SolarSystem system = new SolarSystem();
                        system.Id = Convert.ToInt32(reader.GetAttribute("solarSystemId"));
                        system.ConstellationId = Convert.ToInt32(reader.GetAttribute("constellationID"));
                        system.RegionId = Convert.ToInt32(reader.GetAttribute("regionID"));
                        system.Name = reader.GetAttribute("solarSystemName");
                        system.X = Convert.ToDouble(reader.GetAttribute("x"));
                        system.Y = Convert.ToDouble(reader.GetAttribute("y"));
                        system.Z = Convert.ToDouble(reader.GetAttribute("z"));
                        system.Radius = Convert.ToDouble(reader.GetAttribute("radius"));
                        system.Security = Convert.ToDouble(reader.GetAttribute("security"));
                        table.Add(system.Id, system);
                    }
                }
            }
        }

        public static SolarSystem GetSolarSystemById(int solarSystemId)
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
            public int ConstellationId;
            public int RegionId;
            public string Name;
            public double X;
            public double Y;
            public double Z;
            public double Radius;
            public double Security;
        }
    }
}
