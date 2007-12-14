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

namespace EVEPOSMon
{
    public partial class SelectStarbases : Form
    {
        List<Starbase> m_starbasesList = new List<Starbase>();
        private MainScreen mainScreen = new MainScreen();

        public SelectStarbases()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            
        }

        private void btnLoadStations_Click(object sender, EventArgs e)
        {
            //deactivate the button on first click (is reactivated at end of function)
            //prevents loading data multiple times to the UI
            btnLoadStations.Enabled = false; 
            
            // Clear the master list and station list so it wont affect updates
            lbStations.Rows.Clear();
            m_starbasesList.Clear();
            
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
                cachedUntil = EveSession.GetCacheExpiryUTC(xdoc);
                XmlNodeList starbases = xdoc.DocumentElement.SelectNodes("descendant::rowset/row");
                // For each starbase in the list create an object and place it on the master(m) starbase list
                foreach (XmlNode starbaseNode in starbases)
                {
                    XmlAttributeCollection atts = starbaseNode.Attributes;
                    Starbase starbase = new Starbase();
                    starbase.setValues(atts);
                    /************ Code moved to starbase.setValues() ********* */
                    m_starbasesList.Add(starbase);
                }
            }

            
            //load new list items
            foreach (Starbase s in m_starbasesList)
            {
                lbStations.Rows.Add(new object[] { false, s.StarbaseSystem.regionName, s.StarbaseSystem.constellationName, s.Moon.moonName, s });
            }

            // Dirty delay on button reactivation
            for (int i = 0; i < 5000; i++)
            {
                System.Threading.Thread.Sleep(1);
                Application.DoEvents();
            }
            // Reactivate the button
            btnLoadStations.Enabled = true;
        }

        private void btnGetStationInfo_Click(object sender, EventArgs e)
        {
            bool wasSelection = false;
            mainScreen.clearTabs();
            mainScreen.Visible = false;
            StarbaseMonitor sm;
            TabPage tp;
            for (int i = 0; i < lbStations.RowCount; i++)
            {
                if (lbStations.Rows[i].Cells[0].Value.ToString() == "true")
                {
                    wasSelection = true;
                    // cell 4 is a hidden field with the starbase object
                    Starbase starbase = lbStations.Rows[i].Cells[4].Value as Starbase;

                    starbase.setDetails("http://www.exa-nation.com/corp/StarbaseDetail.xml.aspx?itemId=");

                    /*  because tabs work so well this old display is commented out.
                    StarbaseInfo starbaseInfo = new StarbaseInfo(starbase);
                    starbaseInfo.Show();
                    */
                     
                    tp = new TabPage(starbase.StarbaseSystem.locationID);
                    mainScreen.AddTab(tp);
                    tp.Text = starbase.Moon.moonName;
                    sm = new StarbaseMonitor(starbase);
                    sm.Parent = tp;
                    sm.Dock = DockStyle.Fill;
                }
            }
            // Only display the mainScreen if any of the stations we're checked.
            if (wasSelection)
                mainScreen.Visible = true;
            else
                MessageBox.Show("You must select a starbase in order to have information displayed", "No Starbases Selected", MessageBoxButtons.OK, MessageBoxIcon.Hand );
        }

        // Prompt the user to confirm closing the program and all other windows
        private void SelectStarbases_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = DialogResult.No;
            result = MessageBox.Show("Closing this window will close all others", "Are you sure you want to close", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                return;
            }
            else
                e.Cancel = true;
        }

        private void btnSaveAutoload_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Temp box", "Alert", MessageBoxButtons.OK);
        }
    }
}