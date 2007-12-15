using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using EVEMon.Common;
using System.Threading;
using System.Xml.Serialization;

namespace EVEPOSMon
{
    public partial class SelectStarbases : Form
    {
        Settings m_settings = Settings.GetInstance();
        private MainScreen mainScreen = new MainScreen();
        private FuelCalculator fuelCalculator = new FuelCalculator();

        public SelectStarbases()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addAvailableStarbasesToDataGridView();
        }

        private void btnLoadStations_Click(object sender, EventArgs e)
        {
            btnLoadStations.Enabled = false; 
            
            dgStations.Rows.Clear();
            m_settings.availableStarBases.Clear();
            Starbase.LoadStarbaseListFromApi();
            addAvailableStarbasesToDataGridView();

            btnLoadStations.Enabled = true;
        }

        public void addAvailableStarbasesToDataGridView()
        {
            foreach (Starbase s in m_settings.availableStarBases)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgStations, new object[] { s.monitored, s.StarbaseSystem.regionName, s.StarbaseSystem.constellationName, s.Moon.moonName});
                row.Tag = s;
                dgStations.Rows.Add(row);
            }
        }

        private void btnGetStationInfo_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dgStations.Rows)
            {
                Starbase starbase = row.Tag as Starbase;
                if (starbase.monitored == true)
                    count++;
            }
            if (count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Please select at least one Starbase to monitor");
                return;
            }

            mainScreen.clearTabs();
            mainScreen.Visible = false;
            StarbaseMonitor sm;
            TabPage tp;
            foreach (DataGridViewRow row in dgStations.Rows)
            {
                Starbase starbase = row.Tag as Starbase;

                if (starbase.monitored == true)
                {
                    starbase.LoadStarbaseDetailsFromApi();
                    tp = new TabPage(starbase.StarbaseSystem.locationID);
                    mainScreen.AddTab(tp);
                    tp.Text = starbase.Moon.moonName;
                    sm = new StarbaseMonitor(starbase);
                    sm.Parent = tp;
                    sm.Dock = DockStyle.Fill;
                }
            }

            mainScreen.Visible = true;
            mainScreen.Focus();
        }

        private void SelectStarbases_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            DialogResult result = DialogResult.No;
            result = MessageBox.Show("Closing this window will close all others", "Are you sure you want to close", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                return;
            }
            else
                e.Cancel = true;
             */
            Starbase.SerializeStarbasesToFile(m_settings.SerializedStarbasesFilename, m_settings.availableStarBases);
        }

        private void btnSaveAutoload_Click(object sender, EventArgs e)
        {
            Starbase.SerializeStarbasesToFile(m_settings.SerializedStarbasesFilename, m_settings.availableStarBases);
        }

        private void characterInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginCharacterSelect lcs = new LoginCharacterSelect();
            if (lcs.ShowDialog() == DialogResult.OK)
            {
                m_settings.accountInfo = lcs.accountInfo;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fuelCalculator.Visible = true;
        }

        private void dgStations_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgStations.Rows[e.RowIndex];
            Starbase s = row.Tag as Starbase;
            if (Convert.ToBoolean(row.Cells[0].Value) == true)
            {
                s.monitored = true;
            }
            else
            {
                s.monitored = false;
            }
        }
    }
}