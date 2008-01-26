using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using libeveapi;

namespace eveposmon
{
    public class Settings
    {
        public static BindingList<Account> AccountList = new BindingList<Account>();

        public static void AddAccount(object sender, AccountInfo.AccountAddedEventArgs e)
        {
            Account account = new Account();
            account.UserId = e.UserId;
            account.ApiKey = e.ApiKey;
            account.CharacterListItem = e.CharacterListItem;
            AccountList.Add(account);
        }

        public static void DeleteAccount(object sender, AccountInfo.AccountDeletedEventArgs e)
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
    }
}
