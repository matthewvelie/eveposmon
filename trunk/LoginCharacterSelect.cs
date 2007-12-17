using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using EVEMon.Common;

namespace EVEPOSMon
{
    public partial class LoginCharacterSelect : Form
    {
        public AccountInfo accountInfo;

        public LoginCharacterSelect()
        {
            InitializeComponent();
        }

        private void btnGetCharacters_Click(object sender, EventArgs e)
        {
            if (tbUserId.Text == string.Empty || tbApiKey.Text == string.Empty)
            {
                MessageBox.Show("Please enter your userId and ApiKey");
                return;
            }

            accountInfo = new AccountInfo();
            accountInfo.userId = tbUserId.Text;
            accountInfo.apiKey = tbApiKey.Text;

            //XmlDocument doc = EVEMonWebRequest.LoadXml(@"http://api.eve-online.com/account/Characters.xml.aspx?userid=" + tbUserId.Text + "&apikey=" + tbApiKey.Text);
            XmlDocument doc = EveSession.GetCharList(tbUserId.Text, tbApiKey.Text);
            DateTime cachedUntil = EveSession.GetCacheExpiryUTC(doc);
            XmlNodeList rows = doc.GetElementsByTagName("row");
            foreach (XmlNode row in rows)
            {
                Character c = new Character();
                XmlAttributeCollection attrs = row.Attributes;
                c.name = attrs["name"].InnerText;
                c.characterId = attrs["characterID"].InnerText;
                c.corporationId = attrs["corporationName"].InnerText;
                c.corporationId = attrs["corporationID"].InnerText;
                accountInfo.characters.Add(c);
            }

            CharacterSelect characterSelect = new CharacterSelect(accountInfo);

            if (characterSelect.ShowDialog() == DialogResult.OK)
            {
                foreach (Character c in accountInfo.characters)
                {
                    if (c.name == characterSelect.selectedCharacter.name)
                    {
                        c.selected = true;
                    }
                }
                tbCharacter.Text = characterSelect.selectedCharacter.name;
                characterSelect.selectedCharacter.selected = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbUserId.Text == string.Empty || tbApiKey.Text == string.Empty || tbCharacter.Text == string.Empty)
            {
                MessageBox.Show("Please enter UserID and ApiKey then choose a character");
                DialogResult = DialogResult.None;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://myeve.eve-online.com/api/default.asp");
        }
    }
}