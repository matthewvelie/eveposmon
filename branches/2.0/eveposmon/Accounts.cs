using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using libeveapi;

namespace eveposmon
{
    public delegate void AccountAddedEventHandler(object sender, Accounts.AccountEventArgs e);
    public delegate void AccountDeletedEventHandler(object sender, Accounts.AccountEventArgs e);

    public class Accounts
    {
        public BindingList<Account> AccountList = new BindingList<Account>();

        public void AddAccount(object sender, AccountEventArgs e)
        {
            AccountList.Add(e.Account);
            Settings.Save(Settings.SettingsFile);
        }

        public void DeleteAccount(object sender, AccountEventArgs e)
        {
            AccountList.Remove(e.Account);
            Settings.Save(Settings.SettingsFile);
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

        public class AccountEventArgs : EventArgs
        {
            public Account Account;

            public AccountEventArgs(Account account)
            {
                this.Account = account;
            }

            public AccountEventArgs(int userId, string apiKey, CharacterList.CharacterListItem characterListItem)
            {
                Account account = new Account();
                account.UserId = userId;
                account.ApiKey = apiKey;
                account.CharacterListItem = characterListItem;
                this.Account = account;
            }
        }
    }
}
