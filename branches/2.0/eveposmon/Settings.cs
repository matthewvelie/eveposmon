using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using libeveapi;

namespace eveposmon
{
    public sealed class Settings : ISerializable
    {
        private static Settings instance = new Settings();
        private Settings() {}

        public static Settings Instance
        {
            get { return instance; }
        }

        #region Serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(SettingsSerializationHelper));
        }

        public static void Save(string file)
        {
            using (FileStream s = new FileStream(file, FileMode.Create))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Settings));
                xs.Serialize(s, instance);
            }
        }

        public static void Load(string file)
        {
            if (!File.Exists(file))
            {
                return;
            }

            using (FileStream s = new FileStream(file, FileMode.Open))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Settings));
                instance = xs.Deserialize(s) as Settings;
            }
        }
        #endregion

        #region Constants
        public static readonly string SettingsFile = "Settings.xml";
        #endregion

        #region Accounts
        public Accounts Accounts = new Accounts();
        #endregion

        #region Starbases
        public Starbases Starbases = new Starbases();
        #endregion
    }

    [Serializable]
    internal class SettingsSerializationHelper : IObjectReference
    {
        public object GetRealObject(StreamingContext context)
        {
            return Settings.Instance;
        }
    }
}
