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
            displayAvailableStarbases();
        }

        private void btnLoadStations_Click(object sender, EventArgs e)
        {
            //deactivate the button on first click (is reactivated at end of function)
            //prevents loading data multiple times to the UI
            btnLoadStations.Enabled = false; 
            
            // Clear the master list and station list so it wont affect updates
            dgStations.Rows.Clear();
            m_settings.availableStarBases.Clear();
            
            XmlDocument xdoc = EVEMonWebRequest.LoadXml(@"http://www.exa-nation.com/corp/StarbaseList.xml.aspx");

            string starbaseListError;
            DateTime cachedUntil;

            XmlNode error = xdoc.DocumentElement.SelectSingleNode("descendant::error");
            // If a read error occured, exit
            if (error != null)
            {
                
                starbaseListError = error.InnerText;
                throw new InvalidDataException(starbaseListError);
            }
            // Process xml file 
            else
            {
                // For each starbase in the list create an object and place it on the master(m) starbase list
                cachedUntil = EveSession.GetCacheExpiryUTC(xdoc);
                XmlNodeList starbases = xdoc.DocumentElement.SelectNodes("descendant::rowset/row");
                foreach (XmlNode starbaseNode in starbases)
                {
                    Starbase starbase = new Starbase();
                    starbase.LoadFromListApiXml(starbaseNode, cachedUntil);
                    m_settings.availableStarBases.Add(starbase);
                }
            }

            //load new list items
            displayAvailableStarbases();

            // Dirty delay on button reactivation
            for (int i = 0; i < 5000; i++)
            {
                System.Threading.Thread.Sleep(1);
                Application.DoEvents();
            }
            // Reactivate the button
            btnLoadStations.Enabled = true;
        }

        public void displayAvailableStarbases()
        {
            foreach (Starbase s in m_settings.availableStarBases)
            {
                bool monitored;

                if (s.monitored)
                {
                    monitored = true;
                }
                else
                {
                    monitored = false;
                }

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgStations, new object[] { monitored, s.StarbaseSystem.regionName, s.StarbaseSystem.constellationName, s.Moon.moonName});
                row.Tag = s;
                dgStations.Rows.Add(row);
            }
        }

        private void btnGetStationInfo_Click(object sender, EventArgs e)
        {
            mainScreen.clearTabs();
            mainScreen.Visible = false;
            StarbaseMonitor sm;
            TabPage tp;
            foreach (DataGridViewRow row in dgStations.Rows)
            {
                Starbase starbase = row.Tag as Starbase;

                if (starbase.monitored == true)
                {
                    starbase.setDetails("http://www.exa-nation.com/corp/StarbaseDetail.xml.aspx?itemId=");

                    tp = new TabPage(starbase.StarbaseSystem.locationID);
                    mainScreen.AddTab(tp);
                    tp.Text = starbase.Moon.moonName;
                    sm = new StarbaseMonitor(starbase);
                    sm.Parent = tp;
                    sm.Dock = DockStyle.Fill;
                }
            }

            // Only display the mainScreen if any of the stations we're checked.
            mainScreen.Visible = true;
            mainScreen.Focus();
        }

        // Prompt the user to confirm closing the program and all other windows
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
            serializeStarbases();
        }

        private void btnSaveAutoload_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Temp box", "Alert", MessageBoxButtons.OK);
            serializeStarbases();
        }

        public void serializeStarbases()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Starbase>));
            using (Stream s = new FileStream("Starbases.xml", FileMode.Create))
            {
                serializer.Serialize(s, m_settings.availableStarBases);
            }
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