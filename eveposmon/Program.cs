using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eveposmon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                StaticData.Constellations.LoadFromFile("data/constellations.xml.gz");
                StaticData.TowerResources.LoadFromFile("data/controlTowerResources.xml.gz");
                StaticData.Factions.LoadFromFile("data/factions.xml.gz");
                StaticData.Towers.LoadFromFile("data/invControlTowers.xml.gz");
                StaticData.Fuels.LoadFromFile("data/invFuelTypes.xml.gz");
                StaticData.Moons.LoadFromFile("data/moonData.xml.gz");
                StaticData.Regions.LoadFromFile("data/regions.xml.gz");
                StaticData.SolarSystems.LoadFromFile("data/solarSystem.xml.gz");
                StaticData.SystemFactions.LoadFromFile("data/solarSystemFactions.xml.gz");
                StaticData.Stations.LoadFromFile("data/staStations.xml.gz");
            }
            catch
            {
                MessageBox.Show("Error loading static data, exiting");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
        }
    }
}