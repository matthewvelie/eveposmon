using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EVEPOSMon
{
    public class ControlTower
    {
        public string typeId;
        public string typeName;
        public string description;
        public string volume;
        public string capacity;

        public string strontiumCapacity
        {
            get
            {
                if (volume == "2000")
                {
                    return "12500";
                }
                else if (volume == "4000")
                {
                    return "25000";
                }
                else if (volume == "8000")
                {
                    return "50000";
                }
                else
                {
                    return "-1";
                }
            }
        }

    }

    public class ControlTowerTypes
    {
        List<ControlTower> controlTowersList = new List<ControlTower>();
        Hashtable towersTypeIds = new Hashtable();

        public static ControlTowerTypes Load(string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            ControlTowerTypes ctt = new ControlTowerTypes();

            XmlNodeList towerNodeList = doc.GetElementsByTagName("invTypes");
            foreach (XmlNode tower in towerNodeList)
            {
                ControlTower ct = new ControlTower();
                ct.typeId = tower.ChildNodes[0].InnerText;
                ct.typeName = tower.ChildNodes[1].InnerText;
                ct.description = tower.ChildNodes[2].InnerText;
                ct.volume = tower.ChildNodes[3].InnerText;
                ct.capacity = tower.ChildNodes[4].InnerText;
                ctt.controlTowersList.Add(ct);
            }

            foreach (ControlTower ct in ctt.controlTowersList)
            {
                ctt.towersTypeIds.Add(ct.typeId, ct);
            }

            return ctt;
        }

        public ControlTower GetTowerInfo(string typeId)
        {
            return towersTypeIds[typeId] as ControlTower;
        }
    }
}
