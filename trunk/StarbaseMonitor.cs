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
        private int seconds = 10800;
        private readonly string strontiumTypeId = "16275";

        private void StarbaseMonitor_Load(object sender, EventArgs e)
        {
            loadStationImage(m_starbase.typeId);
            m_starbase.totalFuelVolume = 0;
            m_starbase.totalStrontiumVolume = 0;

            updateForm();
        }

        private void updateForm()
        {
            // Set all the stabase settings labels
            updateOptionLabels();

            dgFuelList.Rows.Clear();

            m_starbase.totalStrontiumVolume = 0;
            m_starbase.totalFuelVolume = 0;
            foreach (Fuel f in m_starbase.FuelList)
            {
                // The fuel name and amount used per hour come from an external xml file
                ResourceEntry fuelInfo = m_settings.towerResources.GetFuelInfo(m_starbase.typeId, f.typeId);
                f.name = fuelInfo.name;
                
                f.volume = fuelInfo.volume;

                // water
                if (fuelInfo.typeId == "16272")
                {
                    if (m_starbase.observedWaterPerHour != 0)
                    {
                        f.quantityUsedPerHour = m_starbase.observedWaterPerHour.ToString();
                    }
                    else
                    {
                        f.quantityUsedPerHour = fuelInfo.quantity;
                    }
                }
                // ozone
                else if (fuelInfo.typeId == "16273")
                {
                    if (m_starbase.observedOzonePerHour != 0)
                    {
                        f.quantityUsedPerHour = m_starbase.observedOzonePerHour.ToString();
                    }
                    else
                    {
                        f.quantityUsedPerHour = fuelInfo.quantity;
                    }
                }
                else
                {
                    f.quantityUsedPerHour = fuelInfo.quantity;
                }

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

            TimeSpan timeLeft = (m_starbase.cachedUntil.ToLocalTime().Subtract(DateTime.Now));
            seconds = timeLeft.Seconds + (timeLeft.Minutes * 60) + (timeLeft.Hours * 60 * 60);

            updateTotalFuelDisplay();
            updateTotalStrontiumDisplay();

            updateStarbaseState();

            updateLowestFuelsDisplay();

            lblTickAt.Text = Convert.ToString(m_starbase.stateTimestamp.Minute);

            dgFuelList.Columns[0].DisplayIndex = 0;
            dgFuelList.Columns[1].DisplayIndex = 1;
            dgFuelList.Columns[2].DisplayIndex = 2;
            lblXmlLastDownloaded.Text = "XML Last Downloaded At: " + m_starbase.lastDownloaded.ToString();
            lblDataCachedUntil.Text = "Data Cached Until: " + m_starbase.cachedUntil.ToLocalTime().ToString();

        }

        private void updateFuels()
        {
            //on the tick update fuels
            System.Windows.Forms.MessageBox.Show("Updating fuel..");
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
            if (seconds != 0)
            {
                seconds--;
            }
            int s = seconds;
            int h = s / 3600;      s = s % 3600;
            int m = s / 60;        s = s % 60;

            string text = "";
            text += h + ":";
            if(m < 10)
            {
                text += "0";
            }
            text += m + ":";
            if(s < 10)
            {
                text += "0";
            }
            text += s;

            //Time to refresh
            if (seconds == 0)
            {
                tmrSecondTick.Stop();
                //Get current values for ozone/water calculations
                int lastXmlLiquidOzone = 0;
                int lastXmlHeavyWater = 0;
                DateTime lastXmlTime = m_starbase.lastDownloaded;

                foreach (Fuel f in m_starbase.FuelList)
                {
                    if (f.typeId == "16273")
                    {
                        lastXmlLiquidOzone = Convert.ToInt32(f.quantity);
                    }
                    if (f.typeId == "16272")
                    {
                        lastXmlHeavyWater = Convert.ToInt32(f.quantity);
                    }
                }

                //Update here
                m_starbase.LoadStarbaseDetailsFromApi();

                //Take new data from api
                int currentXmlLiquidOzone = 0;
                int currentXmlHeavyWater = 0;
                DateTime currentXmlTime = m_starbase.lastDownloaded;

                foreach (Fuel f in m_starbase.FuelList)
                {
                    if (f.typeId == "16273")
                    {
                        currentXmlLiquidOzone = Convert.ToInt32(f.quantity);
                    }
                    if (f.typeId == "16272")
                    {
                        currentXmlHeavyWater = Convert.ToInt32(f.quantity);
                    }
                }

                //calculate the difference between old and new and set
                TimeSpan timeElapsed = currentXmlTime.Subtract(lastXmlTime);
                int ozoneDiff = currentXmlLiquidOzone - lastXmlLiquidOzone;
                int waterDiff = currentXmlHeavyWater - lastXmlHeavyWater;

                //calculate per hr, and make postive (positive loss)
                int ozonePerHr = (ozoneDiff / (timeElapsed.Hours + 1)) * -1;
                int waterPerHr = (waterDiff / (timeElapsed.Hours + 1)) * -1;

                //Make sure they didnt add fuel or take away so its less
                ozonePerHr = ozonePerHr > 150 ? 150 : ozonePerHr;
                waterPerHr = waterPerHr > 150 ? 150 : waterPerHr;

                m_starbase.observedOzonePerHour = ozonePerHr;
                m_starbase.observedWaterPerHour = waterPerHr;

                updateForm();
                tmrSecondTick.Start();
            }

            //check to see if the pos is ticking this second to update (and it's online)
            if (m_starbase.stateTimestamp.Minute == DateTime.Now.Minute && m_starbase.stateTimestamp.Second == DateTime.Now.Second && Convert.ToInt16(m_starbase.state) == 4)
            {
                updateFuels();
            }

            lblTimer.Text = text;
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
        /// Updates the little starbase icon that shows its state
        /// </summary>
        private void updateStarbaseState()
        {
            int state = Convert.ToInt16(m_starbase.state);
            switch (state)
            {
                case 1:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                default:

                    break;
            }
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
