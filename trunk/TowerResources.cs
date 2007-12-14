using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace EVEPOSMon
{
    public class ResourceEntry
    {
        public string towerTypeId;
        public string typeId;
        public string quantity;
        public string purposeText;
        public string name;
        public string description;
        public string volume;
    }

    public class TowerResources
    {
        public List<ResourceEntry> resourceEntries = new List<ResourceEntry>();
        public Hashtable towerTypeIds = new Hashtable();

        public static TowerResources Load(string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine("data", "invControlTowerResources.xml"));
            TowerResources tr = new TowerResources();

            XmlNodeList resourceEntryNodes = doc.GetElementsByTagName("invControlTowerResources");
            foreach (XmlNode reNode in resourceEntryNodes)
            {
                ResourceEntry re = new ResourceEntry();
                re.towerTypeId = reNode.ChildNodes[0].InnerText;
                re.typeId = reNode.ChildNodes[1].InnerText;
                re.quantity = reNode.ChildNodes[2].InnerText;
                re.purposeText = reNode.ChildNodes[3].InnerText;
                re.name = reNode.ChildNodes[4].InnerText;
                re.description = reNode.ChildNodes[5].InnerText;
                re.volume = reNode.ChildNodes[6].InnerText;
                tr.resourceEntries.Add(re);

                if (re.towerTypeId == "12236")
                {
                    System.Diagnostics.Debug.WriteLine(re.typeId);
                }
            }

            foreach (ResourceEntry re in tr.resourceEntries)
            {
                if (tr.towerTypeIds.ContainsKey(re.towerTypeId))
                {
                    (tr.towerTypeIds[re.towerTypeId] as List<ResourceEntry>).Add(re);
                }
                else
                {
                    List<ResourceEntry> reList = new List<ResourceEntry>();
                    reList.Add(re);
                    tr.towerTypeIds.Add(re.towerTypeId, reList);
                }
            }

            return tr;
        }

        public ResourceEntry GetFuelInfo(string towerTypeId, string fuelTypeId)
        {
            List<ResourceEntry> res = towerTypeIds[towerTypeId] as List<ResourceEntry>;
            foreach (ResourceEntry re in res)
            {
                if (re.typeId == fuelTypeId)
                {
                    return re;
                }
            }

            return null;
        }
    }
}
