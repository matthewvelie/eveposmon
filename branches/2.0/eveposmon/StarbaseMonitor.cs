using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace eveposmon
{
    public partial class StarbaseMonitor : UserControl
    {
        private Starbases.MonitoredStarbase starbase;

        public StarbaseMonitor(Starbases.MonitoredStarbase starbase)
        {
            InitializeComponent();
            this.starbase = starbase;
        }

        private void StarbaseMonitor_Load(object sender, EventArgs e)
        {
            updateDisplay();
        }

        private void updateDisplay()
        {
            lblStarbaseName.Text = starbase.TypeName;

            pgFuelBay.Minimum = 0;
            pgFuelBay.Maximum = starbase.FuelCapacity;
            pgFuelBay.Value = Convert.ToInt32(starbase.TotalFuelVolume);

            pgStrontiumBay.Minimum = 0;
            pgStrontiumBay.Maximum = starbase.StrontiumCapacity;
            pgStrontiumBay.Value = Convert.ToInt32(starbase.TotalStrontiumVolume);

            lblFuelBayValue.Text = starbase.TotalFuelVolume.ToString() + " / " + starbase.FuelCapacity.ToString();
            lblStrontiumBayValue.Text = starbase.TotalStrontiumVolume.ToString() + " / " + starbase.StrontiumCapacity.ToString();
        }
    }
}
