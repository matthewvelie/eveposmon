using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace eveposmon.StaticData
{
    public class Moons
    {
        public static Hashtable table = new Hashtable(232767);

        public static void LoadFromFile(string file)
        {
            using (FileStream s = new FileStream(file, FileMode.Open))
            using (GZipStream gz = new GZipStream(s, CompressionMode.Decompress))
            {
                XmlReader reader = XmlReader.Create(gz);
                reader.ReadStartElement("moons");

                while (reader.Read())
                {
                    if (reader.Name == "moon")
                    {
                        Moon moon = new Moon();
                        moon.Id = Convert.ToInt32(reader.GetAttribute("moonId"));
                        moon.Name = reader.GetAttribute("moonName");
                        table.Add(moon.Id, moon);
                    }
                }
            }
        }

        public static Moon GetMoonById(int moonId)
        {
            if (table.Contains(moonId))
            {
                return table[moonId] as Moon;
            }

            return null;
        }

        public class Moon
        {
            public int Id;
            public string Name;
        }
    }
}
