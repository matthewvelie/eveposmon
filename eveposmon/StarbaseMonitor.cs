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
        private Starbases.Starbase starbase;

        public StarbaseMonitor(Starbases.Starbase starbase)
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
        }
    }
}
