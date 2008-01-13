using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace EVEPOSMon
{
    public class StarbaseList
    {
        [XmlElement]
        public DateTime LastUpdated = DateTime.MinValue;

        [XmlElement]
        public DateTime cachedUntil = DateTime.MinValue;

        public static StarbaseList LoadStarbaseListFrom(string filename)
        {
            if (!File.Exists(filename))
            {
                return new StarbaseList();
            }

            using (Stream stream = new FileStream(filename, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(StarbaseList));
                return serializer.Deserialize(stream) as StarbaseList;
            }
        }

        public void SaveStarbaseListTo(string filename)
        {
            using (Stream stream = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(StarbaseList));
                serializer.Serialize(stream, this);
            }
        }
    }
}
