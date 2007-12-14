using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using EVEMon.Common;

namespace EVEPOSMon
{
    public partial class StarbaseInfo : Form
    {
        private Starbase m_starbase;
        private Settings m_settings = Settings.GetInstance();

        public StarbaseInfo(Starbase starbase)
        {
            InitializeComponent();
            m_starbase = starbase;
        }

        private void StarbaseInfo_Load(object sender, EventArgs e)
        {
            ControlTower controlTower = m_settings.controlTowerTypes.GetTowerInfo(m_starbase.typeId);
            lblStarbaseName.Text = controlTower.typeName;

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

            double totalFuelVolume = 0;
            double totalStrontiumVolume = 0;

            foreach (Fuel f in m_starbase.FuelList)
            {
                ResourceEntry fuelInfo = m_settings.towerResources.GetFuelInfo(m_starbase.typeId, f.typeId);
                string name = fuelInfo == null ? f.typeId.ToString() : fuelInfo.name;
                string quantity = f.quantity.ToString();
                string perHour = fuelInfo == null ? "-1" : fuelInfo.quantity;

                TimeSpan timeRemaining = TimeSpan.MinValue;
                string strTimeRemaining = string.Empty;

                if (fuelInfo != null)
                {
                    if (fuelInfo.typeId != "16275")
                    {
                        totalFuelVolume += Convert.ToInt32(f.quantity) * Convert.ToDouble(fuelInfo.volume);
                    }
                    else
                    {
                        totalStrontiumVolume += Convert.ToInt32(f.quantity) * Convert.ToDouble(fuelInfo.volume);
                    }
                    
                    timeRemaining = TimeSpan.FromHours(Convert.ToInt32(quantity) / Convert.ToInt32(perHour));
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
                }

                dgFuelList.Rows.Add(new string[] { name, quantity, perHour + "/hr", strTimeRemaining});
            }

            pgFuelBay.Maximum = Convert.ToInt32(controlTower.capacity);
            pgFuelBay.Minimum = 0;
            pgFuelBay.Value = (int)totalFuelVolume;
            lblFuelBayValue.Text = totalFuelVolume.ToString() + "/" + controlTower.capacity;

            int strontiumCapacity = 0;
            if (controlTower.volume == "2000")
            {
                strontiumCapacity = 12500;
            }
            else if (controlTower.volume == "4000")
            {
                strontiumCapacity = 25000;
            }
            else if (controlTower.volume == "8000")
            {
                strontiumCapacity = 50000;
            }

            pgStrontiumBay.Maximum = strontiumCapacity;
            pgStrontiumBay.Minimum = 0;
            pgStrontiumBay.Value = (int)totalStrontiumVolume;
            lblStrontiumBayValue.Text = totalStrontiumVolume.ToString() + "/" + strontiumCapacity.ToString();

            dgFuelList.Columns[0].DisplayIndex = 0;
            dgFuelList.Columns[1].DisplayIndex = 1;
            dgFuelList.Columns[2].DisplayIndex = 2;
            lblXmlLastDownloaded.Text = "XML Last Downloaded At: " + m_starbase.lastDownloaded.ToString();
            lblDataCachedUntil.Text = "Data Cached Until: " + m_starbase.cachedUntil.ToString();
            loadStationImage(m_starbase.typeId);
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
    }
}