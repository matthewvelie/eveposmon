using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace eveposmon.StaticData
{
    public class Constellations
    {
        private static Hashtable table = new Hashtable();

        public static void LoadFromFile(string file)
        {
            using (FileStream s = new FileStream(file, FileMode.Open))
            using (GZipStream gz = new GZipStream(s, CompressionMode.Decompress))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(gz);

                foreach (XmlNode node in doc.SelectNodes("constellations/constellation"))
                {
                    Constellation constellation = new Constellation();
                    constellation.Id = Convert.ToInt32(node.Attributes["constellationID"].InnerText);
                    constellation.RegionId = Convert.ToInt32(node.Attributes["regionID"].InnerText);
                    constellation.Name = node.Attributes["contellationName"].InnerText;
                    constellation.X = Convert.ToDouble(node.Attributes["x"].InnerText);
                    constellation.Y = Convert.ToDouble(node.Attributes["y"].InnerText);
                    constellation.Z = Convert.ToDouble(node.Attributes["z"].InnerText);
                    constellation.Radius = Convert.ToDouble(node.Attributes["radius"].InnerText);

                    table.Add(constellation.Id, constellation);
                }
            }
        }

        public static Constellation GetConstellationById(int id)
        {
            if (table.ContainsKey(id))
            {
                return table[id] as Constellation;
            }

            return null;
        }

        public class Constellation
        {
            public int Id;
            public int RegionId;
            public string Name;
            public double X;
            public double Y;
            public double Z;
            public double Radius;
        }
    }
}
