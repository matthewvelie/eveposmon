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
            AccountInfo accountInfo = new AccountInfo(Settings.AccountList);
            accountInfo.AccountAdded += new AccountAddedEventHandler(Settings.AddAccount);
            accountInfo.AccountDeleted += new AccountDeletedEventHandler(Settings.DeleteAccount);
            accountInfo.ShowDialog();
        }
    }
}