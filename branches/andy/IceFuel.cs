using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EVEPOSMon
{
    public partial class IceFuel : Form
    {
        public IceFuel()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                txtHeavyWaterQuantity.Enabled = false;
                txtHeliumIsotopesQuantity.Enabled = false;
                txtHydrogenIsotopesQuantity.Enabled = false;
                txtLiquidOzoneQuantity.Enabled = false;
                txtNitrogenIsotopesQuantity.Enabled = false;
                txtOxygenIsotopesQuantity.Enabled = false;
                txtStrontiumQuantity.Enabled = false;
            }
        }
    }
}