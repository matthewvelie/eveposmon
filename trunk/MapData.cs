using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;

namespace EVEPOSMon
{
    public class MapSystem
    {
        public string locationID;
        public string systemName;
        public string security;
        public string constellationName;
        public string regionName;
    }

    public class MapData
    {
        public Hashtable mapSystems = new Hashtable();

        public static MapData Load(string filename)
        {
            using (Stream s = new FileStream(filename, FileMode.Open))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(s);
                MapData md = new MapData();

                XmlNodeList mapSystems = doc.GetElementsByTagName("system");
                foreach (XmlNode systemNode in mapSystems)
                {
                    MapSystem ms = new MapSystem();
                    ms.locationID = systemNode.ChildNodes[0].InnerText;
                    ms.systemName = systemNode.ChildNodes[1].InnerText;
                    ms.security = systemNode.ChildNodes[2].InnerText;
                    ms.constellationName = systemNode.ChildNodes[3].InnerText;
                    ms.regionName = systemNode.ChildNodes[4].InnerText;
                    if (!md.mapSystems.ContainsKey(ms.locationID))
                    {
                        md.mapSystems.Add(ms.locationID, ms);
                    }
                }

                return md;
            }
        }

        public MapSystem GetSystemInfo(string locationId)
        {
            if (mapSystems.ContainsKey(locationId))
            {
                return (mapSystems[locationId] as MapSystem);
            }

            return null;
        }
    }
}
