using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using libeveapi;

namespace eveposmon
{
    public partial class CharacterSelect : Form
    {
        private CharacterList.CharacterListItem selectedCharacterListItem;
        public CharacterList.CharacterListItem SelectedCharacterListItem
        {
            get { return selectedCharacterListItem; }
        }

        public CharacterSelect(CharacterList characterList)
        {
            InitializeComponent();

            lbCharacters.DisplayMember = "Name";
            lbCharacters.DataSource = characterList.CharacterListItems;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lbCharacters.SelectedItem != null)
            {
                selectedCharacterListItem = lbCharacters.SelectedItem as CharacterList.CharacterListItem;
            }
        }

        private void lbCharacters_DoubleClick(object sender, EventArgs e)
        {
            if (lbCharacters.SelectedItem != null)
            {
                selectedCharacterListItem = lbCharacters.SelectedItem as CharacterList.CharacterListItem;
                DialogResult = DialogResult.OK;
            }
        }
    }
}