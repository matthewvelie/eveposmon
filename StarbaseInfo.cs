using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
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
            if (m_starbase.onStandingDrop.enabled == "1")
            {
                lblOnStandingDropValue.Text = "Enabled";
            }
            else
            {
                lblOnStandingDropValue.Text = "Disabled";
            }

            if (m_starbase.onStatusDrop.enabled == "1")
            {
                lblOnStatusDropValue.Text = "Enabled";
            }
            else
            {
                lblOnStatusDropValue.Text = "Disabled";
            }

            if (m_starbase.onAgression.enabled == "1")
            {
                lblOnAggressionValue.Text = "Enabled";
            }
            else
            {
                lblOnAggressionValue.Text = "Disabled";
            }

            if (m_starbase.onCorporationWar.enabled == "1")
            {
                lblOnCorporationWarValue.Text = "Enabled";
            }
            else
            {
                lblOnCorporationWarValue.Text = "Disabled";
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

            foreach (Fuel f in m_starbase.FuelList)
            {
                string requiredQuantity = m_settings.towerResources.GetFuelQuantity(m_starbase.typeId, f.typeId);

                dgFuelList.Rows.Add(new string[] { f.typeId.ToString(), f.quantity.ToString(), requiredQuantity + "/hr" });
            }

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
            switch (typeId)
            {
                case "12236":
                    pbStationImage.Image = Image.FromFile(Path.Combine(basePath, "12236.png"));
                    break;
            }
        }
    }
}