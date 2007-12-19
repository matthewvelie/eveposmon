using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using EVEMon.Common;


namespace EVEPOSMon
{
    public partial class SelectStarbases : Form
    {
        Settings m_settings = Settings.GetInstance();
        private MainScreen mainScreen;
        
        public SelectStarbases(MainScreen screen)
        {
            InitializeComponent();
            this.mainScreen = screen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            addAvailableStarbasesToDataGridView();
        }

        private void btnLoadStations_Click(object sender, EventArgs e)
        {
            btnLoadStations.Enabled = false; 
            
            dgStations.Rows.Clear();
            Starbase.LoadStarbaseListFromApi();
            addAvailableStarbasesToDataGridView();

            btnLoadStations.Enabled = true;
        }

        public void addAvailableStarbasesToDataGridView()
        {
            dgStations.Rows.Clear();
            foreach (Starbase s in m_settings.availableStarBases)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgStations, new object[] { s.monitored, s.StarbaseSystem.regionName, s.StarbaseSystem.constellationName, s.Moon.moonName});
                row.Tag = s;
                dgStations.Rows.Add(row);
            }
        }

        private void populateTabs()
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
            mainScreen.updateTabs();
        }

        private void btnGetStationInfo_Click(object sender, EventArgs e)
        {
            populateTabs();

            this.Visible = false;
            mainScreen.Focus();
        }

        private void SelectStarbases_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private void dgStations_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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