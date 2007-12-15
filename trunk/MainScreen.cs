using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EVEPOSMon
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        public void AddTab(TabPage tp)
        {
            tabControl1.TabPages.Add(tp);
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
            clearTabs();
        }

        public void clearTabs()
        {
            tabControl1.TabPages.Clear();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void aboutEvePOSMonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutDialog = new AboutBox();
            aboutDialog.ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}