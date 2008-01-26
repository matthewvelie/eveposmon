using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using libeveapi;

namespace eveposmon
{
    public delegate void AccountAddedEventHandler(object sender, AccountInfo.AccountAddedEventArgs e);
    public delegate void AccountDeletedEventHandler(object sender, AccountInfo.AccountDeletedEventArgs e);

    public partial class AccountInfo : Form
    {
        public event AccountAddedEventHandler AccountAdded;
        public event AccountDeletedEventHandler AccountDeleted;

        public AccountInfo(BindingList<Settings.Account> accountList)
        {
            InitializeComponent();
            dgAccounts.AutoGenerateColumns = false;
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = accountList;
            dgAccounts.DataSource = bindingSource;
        }

        private void btnGetCharacters_Click(object sender, EventArgs e)
        {
            if (tbUserId.Text == string.Empty || tbApiKey.Text == string.Empty)
            {
                return;
            }

            try
            {
                int userId = Convert.ToInt32(tbUserId.Text);
                CharacterList characterList = EveApi.GetAccountCharacters(userId, tbApiKey.Text);
                CharacterSelect characterSelect = new CharacterSelect(characterList);

                if (characterSelect.ShowDialog() == DialogResult.OK)
                {
                    tbCharacterName.Text = characterSelect.SelectedCharacterListItem.Name;
                    tbCharacterName.Tag = characterSelect.SelectedCharacterListItem;
                    btnAddAccount.Enabled = true;
                }
            }
            catch (System.FormatException)
            {
                return;
            }
        }

        private void tbUserId_TextChanged(object sender, EventArgs e)
        {
            if(tbUserId.Text.Length >= 6 && tbApiKey.Text.Length == 64)
            {
                btnGetCharacters.Enabled = true;
            }else
            {
                btnGetCharacters.Enabled = false;
            }

        }

        private void tbApiKey_TextChanged(object sender, EventArgs e)
        {
            if (tbUserId.Text.Length >= 6 && tbApiKey.Text.Length == 64)
            {
                btnGetCharacters.Enabled = true;
            }
            else
            {
                btnGetCharacters.Enabled = false;
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(tbUserId.Text);
                string apiKey = tbApiKey.Text;
                CharacterList.CharacterListItem characterListItem = tbCharacterName.Tag as CharacterList.CharacterListItem;
                OnAccountAdded(new AccountAddedEventArgs(userId, apiKey, characterListItem));
                btnAddAccount.Enabled = false;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please enter a valid UserId");
            }
        }

        public class AccountAddedEventArgs : EventArgs
        {
            public int UserId;
            public string ApiKey;
            public CharacterList.CharacterListItem CharacterListItem;

            public AccountAddedEventArgs(int userId, string apiKey, CharacterList.CharacterListItem characterListItem)
            {
                this.UserId = userId;
                this.ApiKey = apiKey;
                this.CharacterListItem = characterListItem;
            }
        }

        public class AccountDeletedEventArgs : EventArgs
        {
            public Settings.Account Account;

            public AccountDeletedEventArgs(Settings.Account account)
            {
                this.Account = account;
            }
        }

        protected virtual void OnAccountAdded(AccountAddedEventArgs e)
        {
            if (this.AccountAdded != null)
            {
                AccountAdded(this, e);
            }
        }

        protected virtual void OnAccountDeleted(AccountDeletedEventArgs e)
        {
            if (this.AccountDeleted != null)
            {
                AccountDeleted(this, e);
            }
        }
    }
}