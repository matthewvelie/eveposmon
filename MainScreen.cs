using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVEMon.Common;

namespace EVEPOSMon
{
    public partial class MainScreen : Form
    {
        Settings m_settings = Settings.GetInstance();
        SelectStarbases starbaseWindow;

        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            updateTabs();
        }

        public void updateTabs()
        {
            // Remove tabs for starbases that we are no longer monitoring
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                Starbase starbase = tabPage.Tag as Starbase;
                if (starbase.monitored == false)
                {
                    tabControl1.TabPages.Remove(tabPage);
                }
            }

            foreach (Starbase starbase in m_settings.availableStarBases)
            {
                // Add the starbases that are flagged to be monitored and not already in a tab
                if (starbase.monitored == true && !isStarbaseInTabs(starbase))
                {
                    starbase.LoadStarbaseDetailsFromApi();
                    AddTab(starbase);
                }
            }
            Starbase.SerializeStarbasesToFile(m_settings.SerializedStarbasesFilename, m_settings.availableStarBases);
        }

        private bool isStarbaseInTabs(Starbase starbase)
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                Starbase tabStarBase = tabPage.Tag as Starbase;
                if (tabStarBase.itemId == starbase.itemId)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddTab(Starbase starbase)
        {
            TabPage tp = new TabPage(starbase.StarbaseSystem.locationID);
            tabControl1.TabPages.Add(tp);
            tp.Text = starbase.Moon.moonName;
            tp.Tag = starbase;
            StarbaseMonitor sm = new StarbaseMonitor(starbase);
            sm.Parent = tp;
            sm.Dock = DockStyle.Fill;
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit?",
                "Caption", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                e.Cancel = true; 
        }

        public void clearTabs()
        {
            tabControl1.TabPages.Clear();
        }

        private void aboutEvePOSMonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutDialog = new AboutBox();
            aboutDialog.ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void fuelCalculatorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FuelCalculator fuelCalculator = new FuelCalculator();
            fuelCalculator.Visible = true;
        }

        private void apiKeysToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoginCharacterSelect lcs = new LoginCharacterSelect();
            lcs.ShowDialog();
        }

        private void starbaseSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            starbaseWindow = new SelectStarbases(this);
            starbaseWindow.ShowDialog();
        }

        private void MainScreen_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.Focus();
            WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.Focus();
            WindowState = FormWindowState.Normal;
        }
    }
}