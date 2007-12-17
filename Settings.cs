using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using EVEMon.Common;
using System.Windows.Forms;
using System.Security.Cryptography;
using EVEPOSMon;

namespace EVEMon.Common
{
    [XmlRoot("logindata2")]
    public class Settings
    {
        // Important!!
        
        // Any Updates to settings class members must lock(mutexLock)
        // Also... PLEASE put new settings in the right region 
        //(use outlining and collapse all to see where they go)

        private static Object mutexLock = new Object();
        /// <summary>
        /// Private member to hold currently loaded Settings instance
        /// </summary>
        /// <remarks>
        /// m_instance is only set by either Load() or Restore() and should not be set elsewhere
        /// </remarks>
        private static Settings m_instance = null;

        /// <summary>
        /// Helper method to return current settings instance. If no instance exists, one is loaded
        /// </summary>
        /// <returns>A Settings object for the currently loaded instance</returns>
        public static Settings GetInstance()
        {
            lock (mutexLock)
            {
                if (m_instance == null)
                    m_instance = Load();
                return m_instance;
            }
        }

        public TowerResources towerResources;
        public ControlTowerTypes controlTowerTypes;
        public MapData mapData;
        public MoonData moonData;

        public List<FuelCostEntry> fuelCosts = new List<FuelCostEntry>();
        public List<Starbase> availableStarBases = new List<Starbase>();
        public AccountInfo accountInfo;

        public readonly string SerializedStarbasesFilename = "Starbases.xml";
        public readonly string SerializedFuelCostFilename = "FuelCost.xml";

        public List<Starbase> monitoredStarbases
        {
            get
            {
                List<Starbase> result = new List<Starbase>();
                foreach (Starbase s in availableStarBases)
                {
                    if (s.monitored == true)
                    {
                        result.Add(s); 
                    }
                }
                return result;
            }
        }

        private bool m_useCustomProxySettings = false;
        public bool UseCustomProxySettings
        {
            get { return m_useCustomProxySettings; }
            set
            {
                lock (mutexLock)
                {
                    m_useCustomProxySettings = value;
                }
            }
        }

        private ProxySetting m_httpProxy = new ProxySetting();
        public ProxySetting HttpProxy
        {
            get { return m_httpProxy; }
            set
            {
                lock (mutexLock)
                {
                    m_httpProxy = value;
                }
            }
        }

        private static Settings Load()
        {
            Settings s = new Settings();
            return s;
        }
    }

    [XmlRoot("proxySetting")]
    public class ProxySetting : ICloneable
    {
        private string m_host = String.Empty;

        public string Host
        {
            get { return m_host; }
            set { m_host = value; }
        }

        private int m_port;

        public int Port
        {
            get { return m_port; }
            set { m_port = value; }
        }

        private ProxyAuthType m_authType = ProxyAuthType.None;

        public ProxyAuthType AuthType
        {
            get { return m_authType; }
            set { m_authType = value; }
        }

        private string m_username = String.Empty;

        public string Username
        {
            get { return m_username; }
            set { m_username = value; }
        }

        private string m_password = String.Empty;

        public string Password
        {
            get { return m_password; }
            set { m_password = value; }
        }

        #region ICloneable Members

        public ProxySetting Clone()
        {
            return (ProxySetting)((ICloneable)this).Clone();
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }

    public enum ProxyAuthType
    {
        None,
        SystemDefault,
        Specified
    }

    public enum SystemTrayDisplayOptions
    {
        Never = 1,
        Minimized = 2,
        Always = 3
    }

    [XmlRoot]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        #region IXmlSerializable Members

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XmlSerializer keySer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSer = new XmlSerializer(typeof(TValue));

            reader.Read();
            reader.ReadStartElement("dictionary");
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                reader.ReadStartElement("item");
                reader.ReadStartElement("key");
                TKey key = (TKey)keySer.Deserialize(reader);
                reader.ReadEndElement();

                reader.ReadStartElement("value");
                TValue value = (TValue)valueSer.Deserialize(reader);
                reader.ReadEndElement();

                this.Add(key, value);
                reader.ReadEndElement();
                reader.MoveToContent();
            }
            if (this.Count != 0)
            {
                reader.ReadEndElement();
            }
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer keySer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSer = new XmlSerializer(typeof(TValue));

            writer.WriteStartElement("dictionary");
            foreach (TKey key in this.Keys)
            {
                writer.WriteStartElement("item");

                writer.WriteStartElement("key");
                keySer.Serialize(writer, key);
                writer.WriteEndElement();

                writer.WriteStartElement("value");
                valueSer.Serialize(writer, this[key]);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        #endregion
    }

}
