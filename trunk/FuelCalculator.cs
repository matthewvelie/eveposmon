using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EVEMon.Common;

namespace EVEPOSMon
{
    public partial class FuelCalculator : Form
    {
        private Settings m_settings = Settings.GetInstance();
        
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
           } 
        }

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

    }
}