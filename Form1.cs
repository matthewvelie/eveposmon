using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using EVEMon.Common;

namespace EVEPOSMon
{
    public partial class Form1 : Form
    {
        List<Starbase> m_starbasesList = new List<Starbase>();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadStations_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc = EVEMonWebRequest.LoadXml(@"http://www.exa-nation.com/api/starbaselist.php");

            string starbaseListError;
            DateTime cachedUntil;

            XmlNode error = xdoc.DocumentElement.SelectSingleNode("descendant::error");
            if (error != null)
            {
                starbaseListError = error.InnerText;
                throw new InvalidDataException(starbaseListError);
            }
            else
            {
                cachedUntil = EveSession.GetCacheExpiryUTC(xdoc);
                XmlNodeList starbases = xdoc.DocumentElement.SelectNodes("descendant::rowset/row");
                foreach (XmlNode starbaseNode in starbases)
                {
                    XmlAttributeCollection atts = starbaseNode.Attributes;
                    Starbase starbase = new Starbase();
                    starbase.itemId = atts["itemID"].InnerText;
                    starbase.typeId = atts["typeID"].InnerText;
                    starbase.locationId = atts["locationID"].InnerText;
                    starbase.moonId = atts["moonID"].InnerText;
                    starbase.state = atts["state"].InnerText;
                    starbase.stateTimestamp = EveSession.ConvertCCPTimeStringToDateTime(atts["stateTimestamp"].InnerText);
                    starbase.onlineTimeStamp = EveSession.ConvertCCPTimeStringToDateTime(atts["onlineTimestamp"].InnerText);
                    m_starbasesList.Add(starbase);
                }
            }

            foreach (Starbase s in m_starbasesList)
            {
                lbStations.Items.Add(s);
            }
        }
    }
}