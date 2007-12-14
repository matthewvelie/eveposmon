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
            s.controlTowerTypes = ControlTowerTypes.Load(Application.StartupPath + @"\data\controlTowers.xml");
            s.mapData = MapData.Load(Application.StartupPath + @"\data\mapData.xml");
            s.moonData = MoonData.Load(Application.StartupPath + @"\data\moonData.xml");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SelectStarbases());
        }
    }
}