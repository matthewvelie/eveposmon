using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace EVEPOSMon
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();

            Version vrs = new Version(Application.ProductVersion);
#if DEBUG
            lblVersion.Text = vrs.ToString() + " DEBUG";
#else
            lblVersion.Text = vrs.ToString();
#endif

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://code.google.com/p/eveposmon");
        }

        
    }
}
