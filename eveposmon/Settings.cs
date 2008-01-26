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
        public BindingList<Account> AccountList = new BindingList<Account>();

        public void AddAccount(object sender, AccountInfo.AccountAddedEventArgs e)
        {
            Account account = new Account();
            account.UserId = e.UserId;
            account.ApiKey = e.ApiKey;
            account.CharacterListItem = e.CharacterListItem;
            AccountList.Add(account);
            Settings.Save(Settings.SettingsFile);
        }

        public void DeleteAccount(object sender, AccountInfo.AccountDeletedEventArgs e)
        {
            AccountList.Remove(e.Account);
        }

        /// <summary>
        /// Information about an account that can be used to monitor
        /// starbases.
        /// </summary>
        public class Account
        {
            private int userId;
            private string apiKey;
            private CharacterList.CharacterListItem characterListItem;

            public int UserId
            {
                get { return this.userId; }
                set { this.userId = value; }
            }

            public string ApiKey
            {
                get { return this.apiKey; }
                set { this.apiKey = value; }
            }

            public string CharacterName
            {
                get { return characterListItem.Name; }
            }

            public int CharacterId
            {
                get { return characterListItem.CharacterId; }
            }

            public CharacterList.CharacterListItem CharacterListItem
            {
                get { return this.characterListItem; }
                set { this.characterListItem = value; }
            }
        }
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
