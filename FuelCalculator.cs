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
        public List<FuelCostEntry> fuelCosts = new List<FuelCostEntry>();

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
            foreach (Starbase s in m_settings.availableStarBases)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvStations, new object[] { false, s.Moon.moonName, s });
                row.Tag = s;
                dgvStations.Rows.Add(row);
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

                btnUseStarbases.Visible = false;
                cbEmptyStarbase.Visible = false;
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

                btnUseStarbases.Visible = true;
                cbEmptyStarbase.Visible = true;
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

                btnUseStarbases.Visible = true;
                cbEmptyStarbase.Visible = true;
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

                btnUseStarbases.Visible = true;
                cbEmptyStarbase.Visible = true;
           }
       }
        #endregion

        #region autoUpdatePriceVolume

       private void txtEnrichedUraniumPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtEnrichedUraniumSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtEnrichedUraniumQuantity.Text) * Convert.ToDouble(txtEnrichedUraniumPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtEnrichedUraniumQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtEnrichedUraniumVolume.Text = String.Format("{0:n}",Convert.ToInt32(txtEnrichedUraniumQuantity.Text) * volEnrichedUranium);
                txtEnrichedUraniumSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtEnrichedUraniumQuantity.Text) * Convert.ToDouble(txtEnrichedUraniumPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtOxygenPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtOxygenSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtOxygenQuantity.Text) * Convert.ToDouble(txtOxygenPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtOxygenQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {

                txtOxygenVolume.Text = String.Format("{0:n}",Convert.ToInt32(txtOxygenQuantity.Text) * volOxygen);
                txtOxygenSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtOxygenQuantity.Text) * Convert.ToDouble(txtOxygenPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtCoolantPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtCoolantSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtCoolantQuantity.Text) * Convert.ToDouble(txtCoolantPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtCoolantQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtCoolantVolume.Text = String.Format("{0:n}",Convert.ToInt32(txtCoolantQuantity.Text) * volCoolant);
                txtCoolantSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtCoolantQuantity.Text) * Convert.ToDouble(txtCoolantPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtLiquidOzonePricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtLiquidOzoneSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtLiquidOzoneQuantity.Text) * Convert.ToDouble(txtLiquidOzonePricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtLiquidOzoneQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtLiquidOzoneVolume.Text = String.Format("{0:n}",Convert.ToInt32(txtLiquidOzoneQuantity.Text) * volLiquidOzone);
                txtLiquidOzoneSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtLiquidOzoneQuantity.Text) * Convert.ToDouble(txtLiquidOzonePricePer.Text));
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
                txtHeavyWaterVolume.Text = String.Format("{0:n}",Convert.ToInt32(txtHeavyWaterQuantity.Text) * volHeavyWater);
                txtHeavyWaterSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtHeavyWaterQuantity.Text) * Convert.ToDouble(txtHeavyWaterPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtRoboticsPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtRoboticsSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtRoboticsQuantity.Text) * Convert.ToDouble(txtRoboticsPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtRoboticsQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtRoboticsVolume.Text = String.Format("{0:n}",Convert.ToInt32(txtRoboticsQuantity.Text) * volRobotics);
                txtRoboticsSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtRoboticsQuantity.Text) * Convert.ToDouble(txtRoboticsPricePer.Text));
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
                txtMechanicalPartsVolume.Text = String.Format("{0:n}",Convert.ToInt32(txtMechanicalPartsQuantity.Text) * volMechanicalParts);
                txtMechanicalPartsSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtMechanicalPartsQuantity.Text) * Convert.ToDouble(txtMechanicalPartsPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtHeliumPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtHeliumIsotopesSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtHeliumIsotopesQuantity.Text) * Convert.ToDouble(txtHeliumIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtHeliumIsotopesQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtHeliumIsotopesVolume.Text = String.Format("{0:n}",Convert.ToInt32(txtHeliumIsotopesQuantity.Text) * volIsotopes);
                txtHeliumIsotopesSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtHeliumIsotopesQuantity.Text) * Convert.ToDouble(txtHeliumIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtOxygenIsotopesPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtOxygenIsotopesSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtOxygenIsotopesQuantity.Text) * Convert.ToDouble(txtOxygenIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtOxygenIsotopesQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtOxygenIsotopesVolume.Text = String.Format("{0:n}",Convert.ToInt32(txtOxygenIsotopesQuantity.Text) * volIsotopes);
                txtOxygenIsotopesSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtOxygenIsotopesQuantity.Text) * Convert.ToDouble(txtOxygenIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtHydrogenIsotopesPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtHydrogenIsotopesSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtHydrogenIsotopesQuantity.Text) * Convert.ToDouble(txtHydrogenIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtHydrogenIsotopesQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtHydrogenIsotopesVolume.Text = String.Format("{0:n}",Convert.ToInt32(txtHydrogenIsotopesQuantity.Text) * volIsotopes);
                txtHydrogenIsotopesSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtHydrogenIsotopesQuantity.Text) * Convert.ToDouble(txtHydrogenIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtNitrogenIsotopesPricePer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtNitrogenIsotopesSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtNitrogenIsotopesQuantity.Text) * Convert.ToDouble(txtNitrogenIsotopesPricePer.Text));
            }
            catch (System.FormatException) { }
        }

        private void txtNitrogenIsotopesQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtNitrogenIsotopesVolume.Text = String.Format("{0:n}",Convert.ToInt32(txtNitrogenIsotopesQuantity.Text) * volIsotopes);
                txtNitrogenIsotopesSubtotal.Text = String.Format("{0:n}",Convert.ToInt32(txtNitrogenIsotopesQuantity.Text) * Convert.ToDouble(txtNitrogenIsotopesPricePer.Text));
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
            txtTotalCost.Text = String.Format("{0:n}", 
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
            txtTotalVolume.Text = String.Format("{0:n}",
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
            tspbDownloadingData.Enabled = true;
            tsbUpdatePrices.Enabled = false;

            //download data for each typeId
            txtMechanicalPartsPricePer.Text = downloadPriceData(3689);      //Mechanical Parts
            txtCoolantPricePer.Text = downloadPriceData(9832);              //Coolant
            txtRoboticsPricePer.Text = downloadPriceData(9848);             //Robotics
            txtOxygenPricePer.Text = downloadPriceData(3683);               //Oxygen
            txtOxygenIsotopesPricePer.Text = downloadPriceData(17887);      //Oxygen Isotopes
            txtHeavyWaterPricePer.Text = downloadPriceData(16272);          //Heavy Water
            txtLiquidOzonePricePer.Text = downloadPriceData(16273);         //Liquid Ozone
            txtEnrichedUraniumPricePer.Text = downloadPriceData(44);        //Enriched Uranium
            txtNitrogenIsotopesPricePer.Text = downloadPriceData(17888);    //Nitrogen Isotopes
            txtHeliumIsotopesPricePer.Text = downloadPriceData(16274);      //Helium Isotopes
            txtHydrogenIsotopesPricePer.Text = downloadPriceData(17889);    //Hydrogen Isotopes
            txtStrontiumPricePer.Text = downloadPriceData(16275);           //Strontium Clatherates

            //save data to list
            FuelCostEntry fuelCost = new FuelCostEntry();
            fuelCost.typeId = 3689;
            fuelCost.lastUpdated = System.DateTime.Now;
            fuelCost.costPerUnit = Convert.ToDouble(txtMechanicalPartsPricePer.Text);
            fuelCosts.Add(fuelCost);

            tspbDownloadingData.Enabled = false;
            tspbDownloadingData.Value = 0;

            //serialize and save data
            FuelCostEntry.SerializeFuelToFile(m_settings.SerializedFuelCostFilename, fuelCosts);
            
            tsbUpdatePrices.Enabled = true;
        }

        private string downloadPriceData(int typeId)
        {
            string link = eveCentralWebsite + Convert.ToString(typeId);
            XmlDocument doc = new XmlDocument();
            doc.Load(link);
            XmlNodeList xmlPriceElement = doc.GetElementsByTagName("avg_price");
            string avg_cost = xmlPriceElement.Item(0).InnerText;

            tspbDownloadingData.Value += 8;  //update progress bar

            return String.Format("{0:n}", Math.Round( Convert.ToDecimal( avg_cost ), 2 ) );
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            txtCoolantPricePer.Enabled = txtCoolantPricePer.Enabled ? false : true;
            txtRoboticsPricePer.Enabled = txtRoboticsPricePer.Enabled ? false : true;
            txtOxygenPricePer.Enabled = txtOxygenPricePer.Enabled ? false : true;
            txtMechanicalPartsPricePer.Enabled = txtMechanicalPartsPricePer.Enabled ? false : true;
            txtEnrichedUraniumPricePer.Enabled = txtEnrichedUraniumPricePer.Enabled ? false : true;
            txtHeavyWaterPricePer.Enabled = txtHeavyWaterPricePer.Enabled ? false : true;
            txtLiquidOzonePricePer.Enabled = txtLiquidOzonePricePer.Enabled ? false : true;
            txtStrontiumPricePer.Enabled = txtStrontiumPricePer.Enabled ? false : true;
            txtHeliumIsotopesPricePer.Enabled = txtHeliumIsotopesPricePer.Enabled ? false : true;
            txtHydrogenIsotopesPricePer.Enabled = txtHydrogenIsotopesPricePer.Enabled ? false : true;
            txtNitrogenIsotopesPricePer.Enabled = txtNitrogenIsotopesPricePer.Enabled ? false : true;
            txtOxygenIsotopesPricePer.Enabled = txtOxygenIsotopesPricePer.Enabled ? false : true;
        }

        private void dgvStations_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private int returnQuantity(string towerId, int typeId)
        {
            ResourceEntry fuelNeed = m_settings.towerResources.GetFuelInfo(towerId, typeId);
            return fuelNeed == null ? 0 : Convert.ToInt32(fuelNeed.quantity);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            calculateFuel();
            btnUseStarbases.Enabled = false;
        }

        private void calculateFuel()
        {
            //needed fuel
            int mechanicalPartsFuelNeed = 0;
            int roboticsFuelNeed = 0;
            int oxygenFuelNeed = 0;
            int coolantFuelNeed = 0;
            int enrichedUraniumFuelNeed = 0;
            int heavyWaterFuelNeed = 0;
            int liquidOzoneFuelNeed = 0;
            int heliumIsotopesFuelNeed = 0;
            int hydrogenIsotopesFuelNeed = 0;
            int nitrogenIsotopesFuelNeed = 0;
            int oxygenIsotopesFuelNeed = 0;

            //has fuel
            int mechanicalPartsFuelHas = 0;
            int roboticsFuelHas = 0;
            int oxygenFuelHas = 0;
            int coolantFuelHas = 0;
            int enrichedUraniumFuelHas = 0;
            int heavyWaterFuelHas = 0;
            int liquidOzoneFuelHas = 0;
            int heliumIsotopesFuelHas = 0;
            int hydrogenIsotopesFuelHas = 0;
            int nitrogenIsotopesFuelHas = 0;
            int oxygenIsotopesFuelHas = 0;

            //figure out how much is needed total
            foreach (DataGridViewRow row in dgvStations.Rows)
            {
                Starbase s = row.Tag as Starbase;
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    mechanicalPartsFuelNeed +=  returnQuantity(s.typeId, 3689);
                    roboticsFuelNeed +=         returnQuantity(s.typeId, 9848);
                    oxygenFuelNeed +=           returnQuantity(s.typeId, 3683);
                    coolantFuelNeed +=          returnQuantity(s.typeId, 9832);
                    enrichedUraniumFuelNeed +=  returnQuantity(s.typeId, 44);
                    heavyWaterFuelNeed +=       returnQuantity(s.typeId,16272);
                    liquidOzoneFuelNeed +=      returnQuantity(s.typeId,16273);
                    heliumIsotopesFuelNeed +=   returnQuantity(s.typeId,16274);
                    hydrogenIsotopesFuelNeed += returnQuantity(s.typeId,17889);
                    nitrogenIsotopesFuelNeed += returnQuantity(s.typeId, 17888);
                    oxygenIsotopesFuelNeed +=   returnQuantity(s.typeId,17887);


                    //figure out how much we have, if assume empty leave all as 0
                    if (cbEmptyStarbase.Checked != true)
                    {
                        foreach (Fuel fuel in s.FuelList)
                        {
                            mechanicalPartsFuelHas += fuel.typeId == "3689" ? Convert.ToInt32(fuel.quantity) : 0;
                            roboticsFuelHas += fuel.typeId == "9848" ? Convert.ToInt32(fuel.quantity) : 0;
                            oxygenFuelHas += fuel.typeId == "3683" ? Convert.ToInt32(fuel.quantity) : 0;
                            coolantFuelHas += fuel.typeId == "9832" ? Convert.ToInt32(fuel.quantity) : 0;
                            enrichedUraniumFuelHas += fuel.typeId == "44" ? Convert.ToInt32(fuel.quantity) : 0;
                            heavyWaterFuelHas += fuel.typeId == "16272" ? Convert.ToInt32(fuel.quantity) : 0;
                            liquidOzoneFuelHas += fuel.typeId == "16273" ? Convert.ToInt32(fuel.quantity) : 0;
                            heliumIsotopesFuelHas += fuel.typeId == "16274" ? Convert.ToInt32(fuel.quantity) : 0;
                            hydrogenIsotopesFuelHas += fuel.typeId == "17889" ? Convert.ToInt32(fuel.quantity) : 0;
                            nitrogenIsotopesFuelHas += fuel.typeId == "17888" ? Convert.ToInt32(fuel.quantity) : 0;
                            oxygenIsotopesFuelHas += fuel.typeId == "17887" ? Convert.ToInt32(fuel.quantity) : 0;

                        }
                    }

                    //System.Windows.Forms.MessageBox.Show("The starbase has: " + mechanicalPartsFuelHas + " mech parts on hand.");
                }
            }

            if (rbTimeCalc.Checked)
            {
                if (txtFuelLastDays.Text == "")
                {
                    System.Windows.Forms.MessageBox.Show("Please enter a number of days for the starbases to last.");
                    txtFuelLastDays.Focus();
                    return;
                }

                //System.Windows.Forms.MessageBox.Show("Nitrogen Isotopes needed for one cycle with selected towers: " + nitrogenIsotopesFuelNeed);
                //System.Windows.Forms.MessageBox.Show("Oxygen Isotopes needed for one cycle with selected towers: " + oxygenIsotopesFuelNeed);

                int numberOfCycles = Convert.ToInt32(txtFuelLastDays.Text) * 24;

                //multiply by number of days
                mechanicalPartsFuelNeed *= numberOfCycles;
                roboticsFuelNeed *= numberOfCycles;
                oxygenFuelNeed *= numberOfCycles;
                coolantFuelNeed *= numberOfCycles;
                enrichedUraniumFuelNeed *= numberOfCycles;
                heavyWaterFuelNeed *= numberOfCycles;
                liquidOzoneFuelNeed *= numberOfCycles;
                heliumIsotopesFuelNeed *= numberOfCycles;
                hydrogenIsotopesFuelNeed *= numberOfCycles;
                nitrogenIsotopesFuelNeed *= numberOfCycles;
                oxygenIsotopesFuelNeed *= numberOfCycles;

                txtMechanicalPartsQuantity.Text = mechanicalPartsFuelNeed > mechanicalPartsFuelHas ? Convert.ToString(mechanicalPartsFuelNeed - mechanicalPartsFuelHas) : Convert.ToString(0);
                txtRoboticsQuantity.Text = roboticsFuelNeed > roboticsFuelHas ? Convert.ToString(roboticsFuelNeed - roboticsFuelHas) : Convert.ToString(0);
                txtOxygenQuantity.Text = oxygenFuelNeed > oxygenFuelHas ? Convert.ToString(oxygenFuelNeed - oxygenFuelHas) : Convert.ToString(0);
                txtCoolantQuantity.Text = coolantFuelNeed > coolantFuelHas ? Convert.ToString(coolantFuelNeed - coolantFuelHas) : Convert.ToString(0);
                txtEnrichedUraniumQuantity.Text = enrichedUraniumFuelNeed > enrichedUraniumFuelHas ? Convert.ToString(enrichedUraniumFuelNeed - enrichedUraniumFuelHas) : Convert.ToString(0);
                txtHeavyWaterQuantity.Text = heavyWaterFuelNeed > heavyWaterFuelHas ? Convert.ToString(heavyWaterFuelNeed - heavyWaterFuelHas) : Convert.ToString(0);
                txtLiquidOzoneQuantity.Text = liquidOzoneFuelNeed > liquidOzoneFuelHas ? Convert.ToString(liquidOzoneFuelNeed - liquidOzoneFuelHas) : Convert.ToString(0);
                txtHeliumIsotopesQuantity.Text = heliumIsotopesFuelNeed > heliumIsotopesFuelHas ? Convert.ToString(heliumIsotopesFuelNeed - heliumIsotopesFuelHas) : Convert.ToString(0);
                txtHydrogenIsotopesQuantity.Text = hydrogenIsotopesFuelNeed > hydrogenIsotopesFuelHas ? Convert.ToString(hydrogenIsotopesFuelNeed - hydrogenIsotopesFuelHas) : Convert.ToString(0);
                txtNitrogenIsotopesQuantity.Text = nitrogenIsotopesFuelNeed > nitrogenIsotopesFuelHas ? Convert.ToString(nitrogenIsotopesFuelNeed - nitrogenIsotopesFuelHas) : Convert.ToString(0);
                txtOxygenIsotopesQuantity.Text = oxygenIsotopesFuelNeed > oxygenIsotopesFuelHas ? Convert.ToString(oxygenIsotopesFuelNeed - oxygenIsotopesFuelHas) : Convert.ToString(0);

                //System.Windows.Forms.MessageBox.Show("Oxygen Isotopes needed for " + numberOfCycles / 24 + " days with selected towers: " + oxygenIsotopesFuelNeed);
                //System.Windows.Forms.MessageBox.Show("Nitrogen Isotopes needed for " + numberOfCycles / 24 + " days with selected towers: " + nitrogenIsotopesFuelNeed);
            }

        }

        private void txtFuelLastDays_TextChanged(object sender, EventArgs e)
        {
            calculateFuel();
        }

        private void cbEmptyStarbase_CheckedChanged(object sender, EventArgs e)
        {
            calculateFuel();
        }

        private void dgvStations_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnUseStarbases.Enabled = true;
        }

    }
}