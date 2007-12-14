using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EVEPOSMon
{
    public partial class FuelCalculator : Form
    {
        List<Starbase> m_starbasesList = new List<Starbase>();

        public FuelCalculator()
        {
            InitializeComponent();
        }

        public void loadStarbase()
        {
            foreach (Starbase s in m_starbasesList)
            {
                dgvStations.Rows.Add(new object[] { false, s.StarbaseSystem.regionName, s.StarbaseSystem.constellationName, s.Moon.moonName, s });
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

    }
}