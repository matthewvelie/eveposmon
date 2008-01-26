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
    public partial class AccountInfo : Form
    {
        private int userId;
        private string apiKey;
        private CharacterList.CharacterListItem characterListItem;

        public AccountInfo()
        {
            InitializeComponent();
        }

        private void btnGetCharacters_Click(object sender, EventArgs e)
        {
            if (tbUserId.Text == string.Empty || tbApiKey.Text == string.Empty)
            {
                return;
            }

            try
            {
                userId = Convert.ToInt32(tbUserId.Text);
            }
            catch (System.FormatException)
            {
                return;
            }

            CharacterList characterList = EveApi.GetAccountCharacters(userId, tbApiKey.Text);
            CharacterSelect characterSelect = new CharacterSelect(characterList);

            if (characterSelect.ShowDialog() == DialogResult.OK)
            {
                tbCharacterName.Text = characterSelect.SelectedCharacterListItem.Name;
                this.apiKey = tbApiKey.Text;
                this.characterListItem = characterSelect.SelectedCharacterListItem;
            }
        }

        public int UserId
        {
            get { return userId; }
        }

        public string ApiKey
        {
            get { return apiKey; }
        }

        public CharacterList.CharacterListItem CharacterListItem
        {
            get { return characterListItem; }
        }
    }
}