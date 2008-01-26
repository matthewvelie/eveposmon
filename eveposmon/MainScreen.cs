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
            AccountInfo accountInfo = new AccountInfo(settings.AccountList.Accounts);
            accountInfo.AccountAdded += new AccountAddedEventHandler(settings.AccountList.AddAccount);
            accountInfo.AccountDeleted += new AccountDeletedEventHandler(settings.AccountList.DeleteAccount);
            accountInfo.ShowDialog();
        }
    }
}