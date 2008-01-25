using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace eveposmon.StaticData
{
    public class TowerResources
    {
        private static Hashtable table = new Hashtable();

        public static void LoadFromFile(string file)
        {
            using (FileStream s = new FileStream(file, FileMode.Open))
            using (GZipStream gz = new GZipStream(s, CompressionMode.Decompress))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(gz);

                foreach (XmlNode towerNode in doc.SelectNodes("/towers/tower"))
                {
                    Tower tower = new Tower();
                    tower.TypeId = Convert.ToInt32(towerNode.Attributes["typeID"].InnerText);

                    foreach (XmlNode fuelNode in towerNode.SelectNodes("//fuel"))
                    {
                        Fuel fuel = new Fuel();
                        fuel.TypeId = Convert.ToInt32(fuelNode.Attributes["typeID"].InnerText);
                        fuel.purpose = Convert.ToInt32(fuelNode.Attributes["purpose"].InnerText);
                        fuel.Quantity = Convert.ToInt32(fuelNode.Attributes["quantity"].InnerText);

                        string minSec = fuelNode.Attributes["minsec"].InnerText;
                        if (minSec == string.Empty)
                        {
                            fuel.Minsec = -1;
                        }
                        else
                        {
                            fuel.Minsec = Convert.ToDouble(minSec);
                        }

                        string faction = fuelNode.Attributes["faction"].InnerText;
                        if (faction == string.Empty)
                        {
                            fuel.faction = -1;
                        }
                        else
                        {
                            fuel.faction = Convert.ToInt32(faction);
                        }

                        tower.FuelList.Add(fuel);
                    }

                    table.Add(tower.TypeId, tower);
                }
            }
        }

        public static Tower GetByTypeId(int typeId)
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
            public List<Fuel> FuelList = new List<Fuel>();

            /// <summary>
            /// Based on the security status of the starbase location and the 
            /// id of the faction that controls the starbase location does the 
            /// starbase require this fuel.
            /// </summary>
            /// <param name="fuelTypeId"></param>
            /// <param name="securityStatus">security status of starbase location</param>
            /// <param name="factionId">id of faction that controls the starbase location</param>
            /// <returns></returns>
            public bool RequiresFuel(int fuelTypeId, double securityStatus, int factionId)
            {
                if (requiresFuelBySecurity(fuelTypeId, securityStatus) && requiresFuelByFaction(fuelTypeId, factionId))
                {
                    return true;
                }

                return false;
            }

            /// <summary>
            /// Based on the fuel type and our current security status do
            /// we require this fuel.
            /// </summary>
            /// <param name="fuelTypeId"></param>
            /// <param name="sec">location security status of starbase</param>
            /// <returns></returns>
            private bool requiresFuelBySecurity(int fuelTypeId, double securityStatus)
            {
                foreach (Fuel fuel in FuelList)
                {
                    if (fuel.TypeId == fuelTypeId)
                    {
                        // -1 minsec means we always need it
                        if (fuel.Minsec == -1)
                        {
                            return true;
                        }

                        // if we are above minsec then we need the fuel
                        if (securityStatus >= fuel.Minsec)
                        {
                            return true;
                        }

                        // we are below minsec so we don't need the fuel
                        return false;
                    }
                }

                // didn't find fuel so we don't need it
                return false;
            }

            /// <summary>
            /// Based on the faction that holds the location of the starbase
            /// do we require this fuel.
            /// </summary>
            /// <param name="fuelTypeId"></param>
            /// <param name="faction">id of faction that controls starbase location</param>
            /// <returns></returns>
            private bool requiresFuelByFaction(int fuelTypeId, int factionId)
            {
                foreach (Fuel fuel in FuelList)
                {
                    if (fuel.TypeId == fuelTypeId)
                    {
                        // -1 faction means we always need this fuel
                        if (fuel.faction == -1)
                        {
                            return true;
                        }

                        // faction requires this fuel
                        if (fuel.faction == factionId)
                        {
                            return true;
                        }

                        // faction does not require this fuel
                        return false;
                    }
                }

                // didn't find fuel so we don't need it
                return false;
            }
        }

        public class Fuel
        {
            public int TypeId;
            public int purpose;
            public int Quantity;
            public double Minsec;
            public int faction;
        }
    }
}
