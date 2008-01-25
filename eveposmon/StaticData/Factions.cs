using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace eveposmon.StaticData
{
    public class Factions
    {
        private static Hashtable table = new Hashtable();

        public static void LoadFromFile(string file)
        {
            using (FileStream s = new FileStream(file, FileMode.Open))
            using (GZipStream gz = new GZipStream(s, CompressionMode.Decompress))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(gz);

                foreach (XmlNode node in doc.SelectNodes("factions/faction"))
                {
                    Faction faction = new Faction();
                    faction.Id = Convert.ToInt32(node.Attributes["factionID"].InnerText);
                    faction.Name = node.Attributes["factionName"].InnerText;

                    table.Add(faction.Id, faction);
                }
            }
        }

        public static Faction GetFactionById(int factionId)
        {
            if (table.Contains(factionId))
            {
                return table[factionId] as Faction;
            }

            return null;
        }

        public class Faction
        {
            public int Id;
            public string Name;
        }
    }
}
