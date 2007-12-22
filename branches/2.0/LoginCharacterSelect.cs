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
        private Settings m_settings = Settings.GetInstance();
        private List<Character> newCharacterList = new List<Character>();

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

            CharacterSelect characterSelect;

            // If cached characters are expired then get new data from the api
            if (m_settings.accountInfo.charactersCachedUntil == DateTime.MinValue ||
                DateTime.Now > m_settings.accountInfo.charactersCachedUntil.ToLocalTime())
            {
                //XmlDocument doc = EVEMonWebRequest.LoadXml(@"http://api.eve-online.com/account/Characters.xml.aspx?userid=" + tbUserId.Text + "&apikey=" + tbApiKey.Text);
                XmlDocument doc = EveSession.GetCharList(tbUserId.Text, tbApiKey.Text);
                DateTime cachedUntil = EveSession.GetCacheExpiryUTC(doc);
                m_settings.accountInfo.charactersCachedUntil = cachedUntil;
                XmlNodeList rows = doc.GetElementsByTagName("row");

                foreach (XmlNode row in rows)
                {
                    Character c = new Character();
                    XmlAttributeCollection attrs = row.Attributes;
                    c.name = attrs["name"].InnerText;
                    c.characterId = attrs["characterID"].InnerText;
                    c.corporationId = attrs["corporationName"].InnerText;
                    c.corporationId = attrs["corporationID"].InnerText;
                    newCharacterList.Add(c);
                }

                characterSelect = new CharacterSelect(newCharacterList);
            }
            // character cache is still valid so use that
            else
            {
                characterSelect = new CharacterSelect(m_settings.accountInfo.characters);
            }
            if (characterSelect.ShowDialog() == DialogResult.OK)
            {
                tbCharacter.Text = characterSelect.selectedCharacter.name;
                characterSelect.selectedCharacter.selected = true;
                foreach (Character c in newCharacterList)
                {
                    if (c.name == characterSelect.selectedCharacter.name)
                    {
                        c.selected = true;
                    }
                    else
                    {
                        c.selected = false;
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbUserId.Text == string.Empty || tbApiKey.Text == string.Empty || tbCharacter.Text == string.Empty)
            {
                MessageBox.Show("Please enter UserID and ApiKey then choose a character");
                DialogResult = DialogResult.None;
                return;
            }

            if (cbUseProxy.Checked && tbProxyAddress.Text == String.Empty)
            {
                MessageBox.Show("Please enter a proxy address or uncheck the use proxy option");
                DialogResult = DialogResult.None;
                return;
            }

            if (newCharacterList.Count > 0)
            {
                m_settings.accountInfo.characters = newCharacterList;
            }
            m_settings.accountInfo.userId = tbUserId.Text;
            m_settings.accountInfo.apiKey = tbApiKey.Text;
            m_settings.accountInfo.useProxy = cbUseProxy.Checked;
            m_settings.accountInfo.proxyAddress = tbProxyAddress.Text;
            m_settings.accountInfo.serializeTo(m_settings.SerializedAccountInfoFilename);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://myeve.eve-online.com/api/default.asp");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUseProxy.Checked == true)
            {
                tbProxyAddress.Visible = true;
            }else{
                tbProxyAddress.Visible = false;
            }

        }

        private void LoginCharacterSelect_Load(object sender, EventArgs e)
        {
            tbUserId.Focus();
            tbApiKey.Text = m_settings.accountInfo.apiKey;
            tbUserId.Text = m_settings.accountInfo.userId;

            if (m_settings.accountInfo.SelectedCharacter != null)
            {
                tbCharacter.Text = m_settings.accountInfo.SelectedCharacter.name;
            }

            cbUseProxy.Checked = m_settings.accountInfo.useProxy;
            if (String.IsNullOrEmpty(m_settings.accountInfo.proxyAddress))
            {
                tbProxyAddress.Text = "http://api.eve-online.com";
            }
            else
            {
                tbProxyAddress.Text = m_settings.accountInfo.proxyAddress;
            }
        }
    }
}