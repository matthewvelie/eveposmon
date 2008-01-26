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
        Settings settings = Settings.Instance;

        public MainScreen()
        {
            InitializeComponent();
        }

        private void apiKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountInfo accountInfo = new AccountInfo(settings.Accounts.AccountList);
            accountInfo.AccountAdded += new AccountAddedEventHandler(settings.Accounts.AddAccount);
            accountInfo.AccountDeleted += new AccountDeletedEventHandler(settings.Accounts.DeleteAccount);
            accountInfo.ShowDialog();
        }
    }
}