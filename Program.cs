using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EVEMon.Common;

namespace EVEPOSMon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Settings s = Settings.GetInstance();
            s.towerResources = TowerResources.Load(Application.StartupPath + @"\data\invControlTowerResources.xml");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SelectStarbases());
        }
    }
}