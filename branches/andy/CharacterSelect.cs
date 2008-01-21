using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EVEPOSMon
{
    public partial class CharacterSelect : Form
    {
        List<Character> characters;
        public Character selectedCharacter;

        public CharacterSelect(List<Character> characters)
        {
            InitializeComponent();
            this.characters = characters;
        }

        private void CharacterSelect_Load(object sender, EventArgs e)
        {
            foreach (Character c in characters)
            {
                lbCharacters.Items.Add(c);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lbCharacters.SelectedItems.Count != 1)
            {
                DialogResult = DialogResult.None;
            }

            selectedCharacter = lbCharacters.SelectedItem as Character;
        }

        private void lbCharacters_DoubleClick(object sender, EventArgs e)
        {
            if (lbCharacters.SelectedItems.Count == 1)
            {
                DialogResult = DialogResult.OK;
            }

            selectedCharacter = lbCharacters.SelectedItem as Character;
        }
    }
}