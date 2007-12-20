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
            foreach (Starbase starbase in m_settings.availableStarBases)
            {
                if (starbase.monitored == true)
                {
                    starbase.LoadStarbaseDetailsFromApi();
                    AddTab(starbase);
                }
            }
            Starbase.SerializeStarbasesToFile(m_settings.SerializedStarbasesFilename, m_settings.availableStarBases);
        }

        public void AddTab(Starbase starbase)
        {

            TabPage tp = new TabPage(starbase.StarbaseSystem.locationID);
            tabControl1.TabPages.Add(tp);
            tp.Text = starbase.Moon.moonName;
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
    }
}