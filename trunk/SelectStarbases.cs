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
            lbStations.Items.Clear();
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
                lbStations.Items.Add(s);
            }

            // Dirty delay on button reactivation
            for (int i = 0; i < 500; i++)
            {
                System.Threading.Thread.Sleep(10);
                Application.DoEvents();
            }
            // Reactivate the button
            btnLoadStations.Enabled = true;
        }

        private void btnGetStationInfo_Click(object sender, EventArgs e)
        {

            // get the selected station, use its object method to get the detailed information.
            // Get current seleted station detailed information
            if (lbStations.SelectedItem == null)
            {
                return;
            }

            Starbase starbase = lbStations.SelectedItem as Starbase;
            
            starbase.setDetails("http://www.exa-nation.com/corp/StarbaseDetail.xml.aspx?itemId=");
            /* moved to starbase.setDetails() *************************************************************/

            StarbaseInfo starbaseInfo = new StarbaseInfo(starbase);
            starbaseInfo.Show();

            MainScreen mainScreen = new MainScreen();
            StarbaseMonitor sm = new StarbaseMonitor(starbase);
            TabPage tp = new TabPage("test");
            sm.Parent = tp;
            sm.Dock = DockStyle.Fill;
            mainScreen.AddTab(tp);
            mainScreen.Visible = true;

            
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
    }
}