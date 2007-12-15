using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EVEMon.Common;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;

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
            Settings settings = Settings.GetInstance();

            using (FileStream s = new FileStream(Application.StartupPath + @"\data\controlTowers.xml.gz", FileMode.Open, FileAccess.Read))
            using (GZipStream zs = new GZipStream(s, CompressionMode.Decompress))
            {
                settings.controlTowerTypes = ControlTowerTypes.Load(zs);
            }


            using (FileStream s = new FileStream(Application.StartupPath + @"\data\invControlTowerResources.xml.gz", FileMode.Open, FileAccess.Read))
            using (GZipStream zs = new GZipStream(s, CompressionMode.Decompress))
            {
                settings.towerResources = TowerResources.Load(zs);
            }

            using (FileStream s = new FileStream(Application.StartupPath + @"\data\controlTowers.xml.gz", FileMode.Open, FileAccess.Read))
            using (GZipStream zs = new GZipStream(s, CompressionMode.Decompress))
            {
                settings.controlTowerTypes = ControlTowerTypes.Load(zs);
            }

            using (FileStream s = new FileStream(Application.StartupPath + @"\data\mapData.xml.gz", FileMode.Open, FileAccess.Read))
            using (GZipStream zs = new GZipStream(s, CompressionMode.Decompress))
            {
                settings.mapData = MapData.Load(zs);
            }

            using (FileStream s = new FileStream(Application.StartupPath + @"\data\moonData.xml.gz", FileMode.Open, FileAccess.Read))
            using (GZipStream zs = new GZipStream(s, CompressionMode.Decompress))
            {
                settings.moonData = MoonData.Load(zs);
            }

            if (File.Exists("Starbases.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Starbase>));
                using (Stream s = new FileStream("Starbases.xml", FileMode.Open))
                {
                    settings.availableStarBases = serializer.Deserialize(s) as List<Starbase>;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SelectStarbases());
        }
    }
}