using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace EVEPOSMon
{
    public class Character
    {
        public string name;
        public string characterId;
        public string coportationName;
        public string corporationId;
        public bool selected;

        public override string ToString()
        {
            return name;
        }
    }

    public class AccountInfo
    {
        [XmlElement]
        public string userId;

        [XmlElement]
        public string apiKey;

        [XmlElement]
        public bool useProxy;

        [XmlElement]
        public string proxyAddress;

        [XmlArray]
        public List<Character> characters = new List<Character>();

        [XmlIgnore]
        public Character SelectedCharacter
        {
            get
            {
                foreach (Character c in characters)
                {
                    if (c.selected == true)
                    {
                        return c;
                    }
                }
                return null;
            }
        }

        public void serializeTo(string filename)
        {
            using (Stream stream = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AccountInfo), new Type[] { typeof(Character) });
                serializer.Serialize(stream, this);
            }
        }

        public static AccountInfo LoadFrom(string filename)
        {
            if (!File.Exists(filename))
            {
                return new AccountInfo();
            }

            using (Stream stream = new FileStream(filename, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AccountInfo), new Type[] { typeof(Character) });
                return serializer.Deserialize(stream) as AccountInfo;
            }
        }
    }
}
