using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace eveposmon.StaticData
{
    public class Fuels
    {
        private static Hashtable table = new Hashtable();

        public static void LoadFromFile(string file)
        {
            using (FileStream s = new FileStream(file, FileMode.Open))
            using (GZipStream gz = new GZipStream(s, CompressionMode.Decompress))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(gz);

                foreach (XmlNode node in doc.SelectNodes("fuelItems/item"))
                {
                    Fuel fuel = new Fuel();
                    fuel.TypeId = Convert.ToInt32(node.Attributes["typeID"].InnerText);
                    fuel.GroupId = Convert.ToInt32(node.Attributes["groupID"].InnerText);
                    fuel.GroupName = node.Attributes["groupName"].InnerText;
                    fuel.CategoryId = Convert.ToInt32(node.Attributes["categoryID"].InnerText);
                    fuel.CategoryName = node.Attributes["categoryName"].InnerText;
                    fuel.TypeName = node.Attributes["typeName"].InnerText;
                    fuel.Icon = node.Attributes["icon"].InnerText;
                    fuel.Mass = Convert.ToDouble(node.Attributes["mass"].InnerText);
                    fuel.Volume = Convert.ToDouble(node.Attributes["volume"].InnerText);
                    fuel.Capacity = Convert.ToInt32(node.Attributes["capacity"].InnerText);
                    fuel.Description = node.InnerText;

                    table.Add(fuel.TypeId, fuel);
                }
            }
        }

        public static Fuel GetFuelByTypeId(int typeId)
        {
            if (table.Contains(typeId))
            {
                return table[typeId] as Fuel;
            }

            return null;
        }

        public class Fuel
        {
            public int TypeId;
            public int GroupId;
            public string GroupName;
            public int CategoryId;
            public string CategoryName;
            public string TypeName;
            public string Icon;
            public double Mass;
            public double Volume;
            public int Capacity;
            public string Description;
        }
    }
}
