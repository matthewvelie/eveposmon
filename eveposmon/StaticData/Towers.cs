using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace eveposmon.StaticData
{
    public class Towers
    {
        private static Hashtable table = new Hashtable();

        public static void LoadFromFile(string file)
        {
            using (FileStream s = new FileStream(file, FileMode.Open))
            using (GZipStream gz = new GZipStream(s, CompressionMode.Decompress))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(gz);

                foreach (XmlNode node in doc.SelectNodes("towers/tower"))
                {
                    Tower tower = new Tower();
                    tower.TypeId = Convert.ToInt32(node.Attributes["typeID"].InnerText);
                    tower.TypeName = node.Attributes["typeName"].InnerText;
                    tower.Capacity = Convert.ToInt32(node.Attributes["capacity"].InnerText);
                    tower.Race = (RaceType)Convert.ToInt32(node.Attributes["raceID"].InnerText);
                    tower.Volume = Convert.ToInt32(node.Attributes["volume"].InnerText);
                    tower.Description = node.InnerText;

                    table.Add(tower.TypeId, tower);
                }
            }
        }

        public static Tower GetTowerByTypeId(int typeId)
        {
            if (table.Contains(typeId))
            {
                return table[typeId] as Tower;
            }

            return null;
        }

        public class Tower
        {
            public int TypeId;
            public string TypeName;
            public int Capacity;
            public RaceType Race;
            public int Volume;
            public string Description;
        }

        public enum RaceType
        {
            Caldari = 1,
            Minmatar = 2,
            Amarr = 4,
            Gallente = 8
        }
    }
}
