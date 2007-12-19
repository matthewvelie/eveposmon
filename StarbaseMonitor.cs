using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using EVEMon.Common;
using System.IO;
using System.Text.RegularExpressions;

namespace EVEPOSMon
{
    public partial class StarbaseMonitor : UserControl
    {
        public StarbaseMonitor(Starbase starbase)
        {
            InitializeComponent();
            m_starbase = starbase;
        }

        private Starbase m_starbase;
        private Settings m_settings = Settings.GetInstance();
        private int seconds = 10800000;
        private readonly string strontiumTypeId = "16275";

        private void StarbaseMonitor_Load(object sender, EventArgs e)
        {
            // Set all the stabase settings labels
            updateOptionLabels();

            m_starbase.totalFuelVolume = 0;
            m_starbase.totalStrontiumVolume = 0;

            foreach (Fuel f in m_starbase.FuelList)
            {
                // The fuel name and amount used per hour come from an external xml file
                ResourceEntry fuelInfo = m_settings.towerResources.GetFuelInfo(m_starbase.typeId, f.typeId);
                f.name = fuelInfo.name;
                f.quantityUsedPerHour = fuelInfo.quantity;
                f.volume = fuelInfo.volume;

                // Add this item to our total fuel volume or total strontium volume
                if (fuelInfo.typeId == strontiumTypeId)
                {
                    m_starbase.totalStrontiumVolume += Convert.ToInt32(f.quantity) * Convert.ToDouble(f.volume);
                }
                else
                {
                    m_starbase.totalFuelVolume += Convert.ToInt32(f.quantity) * Convert.ToDouble(f.volume);
                }
                
                // Figure out how long till we run out of this fuel
                f.timeRemaining = TimeSpan.FromHours(Convert.ToInt32(f.quantity) / Convert.ToInt32(f.quantityUsedPerHour));

                // Add this fuel to the datagrid for display
                dgFuelList.Rows.Add(new string[] { f.name, f.quantity, f.quantityUsedPerHour + "/hr", 
                    getTimeRemainingString(f.timeRemaining)});
            }

            updateTotalFuelDisplay();
            updateTotalStrontiumDisplay();

            updateLowestFuelsDisplay();

            dgFuelList.Columns[0].DisplayIndex = 0;
            dgFuelList.Columns[1].DisplayIndex = 1;
            dgFuelList.Columns[2].DisplayIndex = 2;
            lblXmlLastDownloaded.Text = "XML Last Downloaded At: " + m_starbase.lastDownloaded.ToString();
            lblDataCachedUntil.Text = "Data Cached Until: " + m_starbase.cachedUntil.ToLocalTime().ToString();
            loadStationImage(m_starbase.typeId);
        }

        private void updateLowestFuelsDisplay()
        {
            List<Fuel> fuelList = new List<Fuel>(m_starbase.FuelList);
            fuelList.Sort(new CompareFuelByTimeLeft());
            fuelList.Reverse();
            int currentNum = 0;

            //Make Sure Not Strontium
            if (Convert.ToInt32( fuelList[currentNum].typeId ) == 16275)
            {
                currentNum++;
            }
            lblLowestFuelTitle1.Text = fuelList[currentNum].name;
            lblLowestFuelTime1.Text = getTimeRemainingString(fuelList[currentNum].timeRemaining);

            lblPosSustainabilityTime.Text = getTimeRemainingString(fuelList[currentNum].timeRemaining);
            lblPosSustainabilityFuels.Text = fuelList[currentNum].name;

            currentNum++;

            //Make Sure Not Strontium
            if (Convert.ToInt32(fuelList[currentNum].typeId ) == 16275)
            {
                currentNum++;
            }
            lblLowestFuelTitle2.Text = fuelList[currentNum].name;
            lblLowestFuelTime2.Text = getTimeRemainingString(fuelList[currentNum].timeRemaining);
        }

        public void loadStationImage(string typeId)
        {
            string basePath = Path.Combine(Application.StartupPath, "images");

            //test to make sure we have a valid id (only 5 numbers, verify file exists)
            Match m = Regex.Match(typeId, @"(\d{5})");
            if(m.Success)
            {
                string fileName = Path.Combine(basePath, typeId + ".png");
                if(File.Exists(fileName))
                {
                    pbStationImage.Image = Image.FromFile(fileName);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblTimer.Text = Convert.ToString(Convert.ToInt32(lblTimer.Text) - 1);
            seconds--;
            int s = seconds;
            int d = s / 86400;    s = s % 66400;
            int h = s / 3600;     s = s % 3600;
            int m = s / 60;       s = s % 60;
            lblTimer.Text = Convert.ToString(d) + ":" + Convert.ToString(h) + ":" + Convert.ToString(m) + ":" + Convert.ToString(s);
        }

        private void updateTotalFuelDisplay()
        {
            pgFuelBay.Maximum = Convert.ToInt32(m_starbase.Tower.capacity);
            pgFuelBay.Minimum = 0;
            pgFuelBay.Value = (int)m_starbase.totalFuelVolume;
            lblFuelBayValue.Text = m_starbase.totalFuelVolume.ToString() + "/" + m_starbase.Tower.capacity;
        }

        private void updateTotalStrontiumDisplay()
        {
            pgStrontiumBay.Maximum = Convert.ToInt32(m_starbase.Tower.strontiumCapacity);
            pgStrontiumBay.Minimum = 0;
            if (pgStrontiumBay.Value > m_starbase.totalStrontiumVolume)
            {
                System.Windows.Forms.MessageBox.Show("Alert!  The volume in the strontium bay for tower " + m_starbase.Moon.moonName + " has decreased since the last check.");
            }
            pgStrontiumBay.Value = (int)m_starbase.totalStrontiumVolume;
            lblStrontiumBayValue.Text = m_starbase.totalStrontiumVolume.ToString() + "/" + m_starbase.Tower.strontiumCapacity;

        }

        /// <summary>
        /// I put all this crap here to get it out of the way
        /// TODO: think of a better name for this function
        /// </summary>
        private void updateOptionLabels()
        {
            lblStarbaseName.Text = m_starbase.Tower.typeName;

            if (m_starbase.onStandingDrop.enabled == "1")
            {
                lblOnStandingDropValue.Text = "Enabled";
                lblOnStandingDropValue.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblOnStandingDropValue.Text = "Disabled";
                lblOnStandingDropValue.ForeColor = System.Drawing.Color.Red;
            }

            if (m_starbase.onStatusDrop.enabled == "1")
            {
                lblOnStatusDropValue.Text = "Enabled";
                lblOnStatusDropValue.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblOnStatusDropValue.Text = "Disabled";
                lblOnStatusDropValue.ForeColor = System.Drawing.Color.Red;
            }

            if (m_starbase.onAgression.enabled == "1")
            {
                lblOnAggressionValue.Text = "Enabled";
                lblOnAggressionValue.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblOnAggressionValue.Text = "Disabled";
                lblOnAggressionValue.ForeColor = System.Drawing.Color.Red;
            }

            if (m_starbase.onCorporationWar.enabled == "1")
            {
                lblOnCorporationWarValue.Text = "Enabled";
                lblOnCorporationWarValue.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblOnCorporationWarValue.Text = "Disabled";
                lblOnCorporationWarValue.ForeColor = System.Drawing.Color.Red;
            }

            if (m_starbase.allowCorporationMembers == "1")
            {
                lblAllowCorporationMembers.Text = "Allow Corporation Members";
            }
            else
            {
                lblAllowCorporationMembers.Text = "Not Allowing Corporation Members";
            }

            if (m_starbase.allowAllianceMembers == "1")
            {
                lblAllowAllianceMembers.Text = "Allow Alliance Members";
            }
            else
            {
                lblAllowAllianceMembers.Text = "Not Allowing Alliance Members";
            }

            if (m_starbase.claimSovereignty == "1")
            {
                lblClaimingSovereignty.Text = "Claiming Sovereignty";
            }
            else
            {
                lblClaimingSovereignty.Text = "Not Claiming Sovereignty";
            }
        }

        /// <summary>
        /// Create a nicely formatted string pointing out how long we have till the fuel runs out
        /// </summary>
        /// <param name="timeRemaining"></param>
        /// <returns></returns>
        private string getTimeRemainingString(TimeSpan timeRemaining)
        {
            string strTimeRemaining = string.Empty;
            int days = timeRemaining.Days;
            int hours = timeRemaining.Hours;

            if (days > 0)
            {
                strTimeRemaining = days.ToString() + " Days " + hours.ToString() + " Hours";
            }
            else
            {
                strTimeRemaining = hours.ToString() + " Hours";
            }
            return strTimeRemaining;
        }
    }
}
