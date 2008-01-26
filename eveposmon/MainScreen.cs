using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace eveposmon
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void apiKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountInfo accountInfo = new AccountInfo();
            if (accountInfo.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
    }
}