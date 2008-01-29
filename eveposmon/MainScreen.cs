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

            Settings.Instance.Starbases.AddedStarbase += new AddedStarbaseEventHandler(addStarbaseTab);
            Settings.Instance.Starbases.RemovedStarbase += new RemovedStarbaseEventHandler(removeStarbaseTab);
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            addMonitoredStarbases();
        }

        private void apiKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountManager accountInfo = new AccountManager(settings.Accounts.AccountList);
            accountInfo.AccountAdded += new AccountAddedEventHandler(settings.Accounts.AddAccount);
            accountInfo.AccountDeleted += new AccountDeletedEventHandler(settings.Accounts.DeleteAccount);
            accountInfo.ShowDialog();
        }

        private void starbaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectStarbases selectStarbases = new SelectStarbases();
            selectStarbases.SelectedStarbases += new SelectStarbasesEventHandler(settings.Starbases.SelectStarbases);
            selectStarbases.ShowDialog();
        }

        private void addMonitoredStarbases()
        {
            foreach (Starbases.MonitoredStarbase monitoredStarbase in settings.Starbases.MonitoredStarbaseList)
            {
                addStarbaseTab(this, new Starbases.StarbaseEventArgs(monitoredStarbase));
            }
        }

        private void addStarbaseTab(object sender, Starbases.StarbaseEventArgs e)
        {
            TabPage tabPage = new TabPage(e.Starbase.TypeName);
            tabPage.Tag = e.Starbase;
            monitoredStarbaseTabs.TabPages.Add(tabPage);
            StarbaseMonitor starbaseMonitor = new StarbaseMonitor(e.Starbase);
            starbaseMonitor.Parent = tabPage;
            starbaseMonitor.Dock = DockStyle.Fill;
            starbaseMonitor.Focus();
        }

        private void removeStarbaseTab(object sender, Starbases.StarbaseEventArgs e)
        {
            foreach (TabPage tabPage in monitoredStarbaseTabs.TabPages)
            {
                Starbases.MonitoredStarbase starbase = tabPage.Tag as Starbases.MonitoredStarbase;
                if (starbase.ItemId == e.Starbase.ItemId)
                {
                    monitoredStarbaseTabs.TabPages.Remove(tabPage);
                    return;
                }
            }
        }
    }
}