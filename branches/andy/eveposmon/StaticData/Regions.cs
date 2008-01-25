using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace eveposmon.StaticData
{
    public class Regions
    {
        private static Hashtable table = new Hashtable();

        public static void LoadFromFile(string file)
        {
            using (FileStream s = new FileStream(file, FileMode.Open))
            using (GZipStream gz = new GZipStream(s, CompressionMode.Decompress))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(gz);

                foreach (XmlNode node in doc.SelectNodes("regions/region"))
                {
                    Region region = new Region();
                    region.RegionId = Convert.ToInt32(node.Attributes["regionID"].InnerText);
                    region.Name = node.Attributes["regionName"].InnerText;
                    region.X = Convert.ToDouble(node.Attributes["x"].InnerText);
                    region.Y = Convert.ToDouble(node.Attributes["y"].InnerText);
                    region.Z = Convert.ToDouble(node.Attributes["z"].InnerText);
                    region.Radius = Convert.ToDouble(node.Attributes["radius"].InnerText);
                    region.FactionId = Convert.ToInt32(node.Attributes["factionID"].InnerText);

                    table.Add(region.RegionId, region);
                }
            }
        }

        public static Region GetRegionById(int id)
        {
            if (table.ContainsKey(id))
            {
                return table[id] as Region;
            }

            return null;
        }

        public class Region
        {
            public int RegionId;
            public string Name;
            public double X;
            public double Y;
            public double Z;
            public double Radius;
            public int FactionId;
        }
    }
}
