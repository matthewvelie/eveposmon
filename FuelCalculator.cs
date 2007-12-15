using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using EVEMon.Common;

namespace EVEPOSMon
{
    public partial class FuelCalculator : Form
    {
        private Settings m_settings = Settings.GetInstance();

        const string eveCentralWebsite = "http://eve-central.com/home/marketstat_xml.html?typeid=";

        const double volEnrichedUranium = 1;
        const double volCoolant = 2;
        const double volOxygen = 1;
        const double volMechanicalParts = 1;
        const double volRobotics = 2;
        const double volHeavyWater = .4;
        const double volLiquidOzone = .4;
        const double volIsotopes = .15;
        const double volCharter = .1;
        const double volStrontium = 3;

        public FuelCalculator()
        {
            InitializeComponent();
            loadStarbase();
        }

        public void loadStarbase()
        {
            dgvStations.Rows.Clear();
            foreach ( Starbase s in m_settings.availableStarBases )
            {
                dgvStations.Rows.Add(new object[] { false, s.Moon.moonName, s });
            }

        }

        #region changeTypeOfCalc

        private void changeQuantityFieldEnable(bool state)
        {
            //Enable Quantity Fields
            this.txtCoolantQuantity.Enabled = state;
            this.txtEnrichedUraniumQuantity.Enabled = state;
            this.txtHeavyWaterQuantity.Enabled = state;
            this.txtHeliumIsotopesQuantity.Enabled = state;
            this.txtHydrogenIsotopesQuantity.Enabled = state;
            this.txtLiquidOzoneQuantity.Enabled = state;
            this.txtMechanicalPartsQuantity.Enabled = state;
            this.txtNitrogenIsotopesQuantity.Enabled = state;
            this.txtOxygenIsotopesQuantity.Enabled = state;
            this.txtOxygenQuantity.Enabled = state;
            this.txtRoboticsQuantity.Enabled = state;
        }

        private void rbManualCalc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbManualCalc.Checked == true)
            {
                //Disable labels, in manual mode
                this.lblAmtToSpendIsk.Enabled = false;
                this.lblAmtToSpend.Enabled = false;
                this.lblFuelShouldLast.Enabled = false;
                this.lblFuelDays.Enabled = false;
                this.lblHaulerCargoSize.Enabled = false;
                this.lblHaulerM3.Enabled = false;

                //Disable textboxes, in manual mode
                this.txtAmtToSpend.Enabled = false;
                this.txtCargoSize.Enabled = false;
                this.txtFuelLastDays.Enabled = false;

                //Enable Quantity Fields
                changeQuantityFieldEnable(true);
                dgvStations.Enabled = false;
                dgvStations.Visible = false;

                //
                lblFuelWilllastTotal.Enabled = false;
                lblTotalDaysUnit.Enabled = false;
                txtTotalFuelLastDays.Enabled = false;
            }
        }

        private void rbCargoCalc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCargoCalc.Checked == true)
            {
                this.lblAmtToSpendIsk.Enabled = false;
                this.lblAmtToSpend.Enabled = false;
                this.lblFuelShouldLast.Enabled = false;
                this.lblFuelDays.Enabled = false;
                this.lblHaulerCargoSize.Enabled = true;
                this.lblHaulerM3.Enabled = true;

                this.txtAmtToSpend.Enabled = false;
                this.txtCargoSize.Enabled = true;
                this.txtFuelLastDays.Enabled = false;

                changeQuantityFieldEnable(false);
                dgvStations.Enabled = true;
                dgvStations.Visible = true;

                lblFuelWilllastTotal.Enabled = true;
                lblTotalDaysUnit.Enabled = true;
                txtTotalFuelLastDays.Enabled = true;
            }
        }

        private void rbTimeCalc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTimeCalc.Checked == true)
            {
                this.lblAmtToSpendIsk.Enabled = false;
                this.lblAmtToSpend.Enabled = false;
                this.lblFuelShouldLast.Enabled = true;
                this.lblFuelDays.Enabled = true;
                this.lblHaulerCargoSize.Enabled = false;
                this.lblHaulerM3.Enabled = false;

                this.txtAmtToSpend.Enabled = false;
                this.txtCargoSize.Enabled = false;
                this.txtFuelLastDays.Enabled = true;

                changeQuantityFieldEnable(false);
                dgvStations.Enabled = true;
                dgvStations.Visible = true;

                lblFuelWilllastTotal.Enabled = true;
                lblTotalDaysUnit.Enabled = true;
                txtTotalFuelLastDays.Enabled = true;
            }
        }

        private void rbIskCalc_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIskCalc.Checked == true)
            {
                this.lblAmtToSpendIsk.Enabled = true;
                this.lblAmtToSpend.Enabled = true;
                this.lblFuelShouldLast.Enabled = false;
                this.lblFuelDays.Enabled = false;
                this.lblHaulerCargoSize.Enabled = false;
                this.lblHaulerM3.Enabled = false;

                this.txtAmtToSpend.Enabled = true;
                this.txtCargoSize.Enabled = false;
                this.txtFuelLastDays.Enabled = false;

                changeQuantityFieldEnable(false);
                dgvStations.Enabled = true;
                dgvStations.Visible = true;

                lblFuelWilllastTotal.Enabled = true;
                lblTotalDaysUnit.Enabled = true;
                txtTotalFuelLastDays.Enabled = true;
           }
       }
        #endregion

       #region autoUpdatePriceVolume

       private void txtEnrichedUraniumPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtEnrichedUraniumSubtotal.Text = Convert.ToString(Convert.ToInt32(txtEnrichedUraniumQuantity.Text) * Convert.ToDouble(txtEnrichedUraniumPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtEnrichedUraniumQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtEnrichedUraniumVolume.Text = Convert.ToString(Convert.ToInt32(txtEnrichedUraniumQuantity.Text) * volEnrichedUranium);
                txtEnrichedUraniumSubtotal.Text = Convert.ToString(Convert.ToInt32(txtEnrichedUraniumQuantity.Text) * Convert.ToDouble(txtEnrichedUraniumPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtOxygenPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtOxygenSubtotal.Text = Convert.ToString(Convert.ToInt32(txtOxygenQuantity.Text) * Convert.ToDouble(txtOxygenPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtOxygenQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {

                txtOxygenVolume.Text = Convert.ToString(Convert.ToInt32(txtOxygenQuantity.Text) * volOxygen);
                txtOxygenSubtotal.Text = Convert.ToString(Convert.ToInt32(txtOxygenQuantity.Text) * Convert.ToDouble(txtOxygenPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtCoolantPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtCoolantSubtotal.Text = Convert.ToString(Convert.ToInt32(txtCoolantQuantity.Text) * Convert.ToDouble(txtCoolantPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtCoolantQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtCoolantVolume.Text = Convert.ToString(Convert.ToInt32(txtCoolantQuantity.Text) * volCoolant);
                txtCoolantSubtotal.Text = Convert.ToString(Convert.ToInt32(txtCoolantQuantity.Text) * Convert.ToDouble(txtCoolantPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtLiquidOzonePricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtLiquidOzoneSubtotal.Text = Convert.ToString(Convert.ToInt32(txtLiquidOzoneQuantity.Text) * Convert.ToDouble(txtLiquidOzonePricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtLiquidOzoneQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtLiquidOzoneVolume.Text = Convert.ToString(Convert.ToInt32(txtLiquidOzoneQuantity.Text) * volLiquidOzone);
                txtLiquidOzoneSubtotal.Text = Convert.ToString(Convert.ToInt32(txtLiquidOzoneQuantity.Text) * Convert.ToDouble(txtLiquidOzonePricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtHeavyWaterPricePer_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHeavyWaterQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtHeavyWaterVolume.Text = Convert.ToString(Convert.ToInt32(txtHeavyWaterQuantity.Text) * volHeavyWater);
                txtHeavyWaterSubtotal.Text = Convert.ToString(Convert.ToInt32(txtHeavyWaterQuantity.Text) * Convert.ToDouble(txtHeavyWaterPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtRoboticsPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtRoboticsSubtotal.Text = Convert.ToString(Convert.ToInt32(txtRoboticsQuantity.Text) * Convert.ToDouble(txtRoboticsPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtRoboticsQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtRoboticsVolume.Text = Convert.ToString(Convert.ToInt32(txtRoboticsQuantity.Text) * volRobotics);
                txtRoboticsSubtotal.Text = Convert.ToString(Convert.ToInt32(txtRoboticsQuantity.Text) * Convert.ToDouble(txtRoboticsPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtMechanicalPartsPricePer_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMechanicalPartsQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMechanicalPartsVolume.Text = Convert.ToString(Convert.ToInt32(txtMechanicalPartsQuantity.Text) * volMechanicalParts);
                txtMechanicalPartsSubtotal.Text = Convert.ToString(Convert.ToInt32(txtMechanicalPartsQuantity.Text) * Convert.ToDouble(txtMechanicalPartsPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtHeliumPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtHeliumIsotopesSubtotal.Text = Convert.ToString(Convert.ToInt32(txtHeliumIsotopesQuantity.Text) * Convert.ToDouble(txtHeliumIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtHeliumIsotopesQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtHeliumIsotopesVolume.Text = Convert.ToString(Convert.ToInt32(txtHeliumIsotopesQuantity.Text) * volIsotopes);
                txtHeliumIsotopesSubtotal.Text = Convert.ToString(Convert.ToInt32(txtHeliumIsotopesQuantity.Text) * Convert.ToDouble(txtHeliumIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtOxygenIsotopesPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtOxygenIsotopesSubtotal.Text = Convert.ToString(Convert.ToInt32(txtOxygenIsotopesQuantity.Text) * Convert.ToDouble(txtOxygenIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtOxygenIsotopesQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtOxygenIsotopesVolume.Text = Convert.ToString(Convert.ToInt32(txtOxygenIsotopesQuantity.Text) * volIsotopes);
                txtOxygenIsotopesSubtotal.Text = Convert.ToString(Convert.ToInt32(txtOxygenIsotopesQuantity.Text) * Convert.ToDouble(txtOxygenIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtHydrogenIsotopesPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtHydrogenIsotopesSubtotal.Text = Convert.ToString(Convert.ToInt32(txtHydrogenIsotopesQuantity.Text) * Convert.ToDouble(txtHydrogenIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtHydrogenIsotopesQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtHydrogenIsotopesVolume.Text = Convert.ToString(Convert.ToInt32(txtHydrogenIsotopesQuantity.Text) * volIsotopes);
                txtHydrogenIsotopesSubtotal.Text = Convert.ToString(Convert.ToInt32(txtHydrogenIsotopesQuantity.Text) * Convert.ToDouble(txtHydrogenIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtNitrogenIsotopesPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtNitrogenIsotopesSubtotal.Text = Convert.ToString(Convert.ToInt32(txtNitrogenIsotopesQuantity.Text) * Convert.ToDouble(txtNitrogenIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtNitrogenIsotopesQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtNitrogenIsotopesVolume.Text = Convert.ToString(Convert.ToInt32(txtNitrogenIsotopesQuantity.Text) * volIsotopes);
                txtNitrogenIsotopesSubtotal.Text = Convert.ToString(Convert.ToInt32(txtNitrogenIsotopesQuantity.Text) * Convert.ToDouble(txtNitrogenIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

       #endregion

        #region updateTotalSubtotals

        private void txtEnrichedUraniumSubtotal_TextChanged(object sender, EventArgs e)
        {
            updateSubtotal();
        }

        private void txtOxygenSubtotal_TextChanged(object sender, EventArgs e)
        {
            updateSubtotal();
        }

        private void txtCoolantSubtotal_TextChanged(object sender, EventArgs e)
        {
            updateSubtotal();
        }

        private void txtRoboticsSubtotal_TextChanged(object sender, EventArgs e)
        {
            updateSubtotal();
        }

        private void txtMechanicalPartsSubtotal_TextChanged(object sender, EventArgs e)
        {
            updateSubtotal();
        }

        private void txtStrontiumSubtotal_TextChanged(object sender, EventArgs e)
        {
            updateSubtotal();
        }

        private void txtLiquidOzoneSubtotal_TextChanged(object sender, EventArgs e)
        {
            updateSubtotal();
        }

        private void txtHeavyWaterSubtotal_TextChanged(object sender, EventArgs e)
        {
            updateSubtotal();
        }

        private void txtHeliumIsotopesSubtotal_TextChanged(object sender, EventArgs e)
        {
            updateSubtotal();
        }

        private void txtOxygenIsotopesSubtotal_TextChanged(object sender, EventArgs e)
        {
            updateSubtotal();
        }

        private void txtHydrogenIsotopesSubtotal_TextChanged(object sender, EventArgs e)
        {
            updateSubtotal();
        }

        private void txtNitrogenIsotopesSubtotal_TextChanged(object sender, EventArgs e)
        {
            updateSubtotal();
        }

        private void updateSubtotal()
        {
            txtTotalCost.Text = Convert.ToString(
                Convert.ToDouble(txtNitrogenIsotopesSubtotal.Text) +
                Convert.ToDouble(txtOxygenIsotopesSubtotal.Text) +
                Convert.ToDouble(txtHeliumIsotopesSubtotal.Text) +
                Convert.ToDouble(txtHydrogenIsotopesSubtotal.Text) +
                Convert.ToDouble(txtHeavyWaterSubtotal.Text) +
                Convert.ToDouble(txtLiquidOzoneSubtotal.Text) +
                Convert.ToDouble(txtStrontiumSubtotal.Text) +
                Convert.ToDouble(txtMechanicalPartsSubtotal.Text) +
                Convert.ToDouble(txtRoboticsSubtotal.Text) +
                Convert.ToDouble(txtCoolantSubtotal.Text) +
                Convert.ToDouble(txtOxygenSubtotal.Text) +
                Convert.ToDouble(txtEnrichedUraniumSubtotal.Text)
                );
        }
        #endregion

        #region updateTotalVolume
        private void txtEnrichedUraniumVolume_TextChanged(object sender, EventArgs e)
        {
            updateTotalVolume();
        }

        private void txtOxygenVolume_TextChanged(object sender, EventArgs e)
        {
            updateTotalVolume();
        }

        private void txtCoolantVolume_TextChanged(object sender, EventArgs e)
        {
            updateTotalVolume();
        }

        private void txtRoboticsVolume_TextChanged(object sender, EventArgs e)
        {
            updateTotalVolume();
        }

        private void txtMechanicalPartsVolume_TextChanged(object sender, EventArgs e)
        {
            updateTotalVolume();
        }

        private void txtStrontiumVolume_TextChanged(object sender, EventArgs e)
        {
            updateTotalVolume();
        }

        private void txtLiquidOzoneVolume_TextChanged(object sender, EventArgs e)
        {
            updateTotalVolume();
        }

        private void txtHeavyWaterVolume_TextChanged(object sender, EventArgs e)
        {
            updateTotalVolume();
        }

        private void txtHeliumIsotopesVolume_TextChanged(object sender, EventArgs e)
        {
            updateTotalVolume();
        }

        private void txtOxygenIsotopesVolume_TextChanged(object sender, EventArgs e)
        {
            updateTotalVolume();
        }

        private void txtHydrogenIsotopesVolume_TextChanged(object sender, EventArgs e)
        {
            updateTotalVolume();
        }

        private void txtNitrogenIsotopesVolume_TextChanged(object sender, EventArgs e)
        {
            updateTotalVolume();
        }

        private void updateTotalVolume()
        {
            txtTotalVolume.Text = Convert.ToString(
                Convert.ToDouble(txtNitrogenIsotopesVolume.Text) +
                Convert.ToDouble(txtOxygenIsotopesVolume.Text) +
                Convert.ToDouble(txtHeliumIsotopesVolume.Text) +
                Convert.ToDouble(txtHydrogenIsotopesVolume.Text) +
                Convert.ToDouble(txtHeavyWaterVolume.Text) +
                Convert.ToDouble(txtLiquidOzoneVolume.Text) +
                Convert.ToDouble(txtStrontiumVolume.Text) +
                Convert.ToDouble(txtMechanicalPartsVolume.Text) +
                Convert.ToDouble(txtRoboticsVolume.Text) +
                Convert.ToDouble(txtCoolantVolume.Text) +
                Convert.ToDouble(txtOxygenVolume.Text) +
                Convert.ToDouble(txtEnrichedUraniumVolume.Text)
                );
        }
#endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //download data for each typeId
            txtMechanicalPartsPricePer.Text = downloadPriceData(3689); //mech parts
            txtCoolantPricePer.Text = downloadPriceData(9832); //Coolant
            txtRoboticsPricePer.Text = downloadPriceData(9848); //Robotics
            txtOxygenPricePer.Text = downloadPriceData(3683); //Oxygen
            txtOxygenIsotopesPricePer.Text = downloadPriceData(17887); //Oxygen Isotopes
            txtHeavyWaterPricePer.Text = downloadPriceData(16272); //Heavy Water
            txtLiquidOzonePricePer.Text = downloadPriceData(16273); //Liquid Ozone
            txtEnrichedUraniumPricePer.Text = downloadPriceData(44); //Enriched Uranium
            txtNitrogenIsotopesPricePer.Text = downloadPriceData(16275); //Nitrogen Isotopes
            txtHeliumIsotopesPricePer.Text = downloadPriceData(16274); //Helium Isotopes
            txtHydrogenIsotopesPricePer.Text = downloadPriceData(17889); //Hydrogen Isotopes
        }

        private string downloadPriceData(int typeId)
        {
            string link = eveCentralWebsite + Convert.ToString(typeId);
            XmlDocument doc = new XmlDocument();
            doc.Load(link);
            XmlNodeList xmlPriceElement = doc.GetElementsByTagName("avg_price");
            string avg_cost = xmlPriceElement.Item(0).InnerText;
            
            return Convert.ToString( Math.Round( Convert.ToDecimal( avg_cost ), 2 ) );
        }


    }
}