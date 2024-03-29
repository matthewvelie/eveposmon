using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EVEMon.Common;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;

namespace EVEPOSMon
{
    static class Program
    {
        public static Stopwatch stopWatch = new Stopwatch();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            stopWatch.Start();
            Settings settings = Settings.GetInstance();

            Version vrs = new Version(Application.ProductVersion);
            //MessageBox.Show("Major: " + vrs.Major + "\r\nMinor: " + vrs.Minor + "Build: " + vrs.Build + "\r\nRevision: " + vrs.Revision);

            XmlDocument doc = EveSession.GetUpdateDocument();
            try
            {
                XmlNodeList rowsNodeList = doc.GetElementsByTagName("current");
                foreach (XmlNode r in rowsNodeList)
                {
                    XmlAttributeCollection attrs = r.Attributes;
                    int major = Convert.ToInt32( attrs["major"].InnerText );
                    int minor = Convert.ToInt32( attrs["minor"].InnerText );
                    int build = Convert.ToInt32(attrs["build"].InnerText);
                    int revision = Convert.ToInt32( attrs["revision"].InnerText );
                    int disable = Convert.ToInt32(attrs["disable"].InnerText);
                    string message = attrs["message"].InnerText;
                    Version online = new Version(major, minor, build, revision);
                    
                    if( Convert.ToBoolean( online.CompareTo(vrs) ) )
                    {
                        if( Convert.ToBoolean(disable ) )
                        {
                            System.Windows.Forms.MessageBox.Show("There is a newer version available, this is a mandatory upgrade. \nYou are running " + vrs.ToString() + ", and " + online.ToString() + " is available.  \n\nPlease visit: http://code.google.com/p/eveposmon/ for the latest downloads.\n\nAdditional Information: " + message);
                            Environment.Exit(1);
                        }else
                        {
                            System.Windows.Forms.MessageBox.Show("There is a newer version available.  \nYou are running " + vrs.ToString() + ", and " + online.ToString() + " is available.  \n\nPlease visit: http://code.google.com/p/eveposmon/ for the latest downloads.\n\nAdditional Information: " + message);
                        }
                    }

                }
            }
            catch
            {
            }

            Debug.WriteLine("Update Check finished at: " + Program.stopWatch.Elapsed);

            using (FileStream s = new FileStream(Application.StartupPath + @"\data\controlTowers.xml.gz", FileMode.Open, FileAccess.Read))
            using (GZipStream zs = new GZipStream(s, CompressionMode.Decompress))
            {
                settings.controlTowerTypes = ControlTowerTypes.Load(zs);
            }

            Debug.WriteLine("Control Towers Finished Loading At: " + Program.stopWatch.Elapsed);

            using (FileStream s = new FileStream(Application.StartupPath + @"\data\invControlTowerResources.xml.gz", FileMode.Open, FileAccess.Read))
            using (GZipStream zs = new GZipStream(s, CompressionMode.Decompress))
            {
                settings.towerResources = TowerResources.Load(zs);
            }
            Debug.WriteLine("Control Towers Resources Finished Loading At: " + Program.stopWatch.Elapsed);

            using (FileStream s = new FileStream(Application.StartupPath + @"\data\controlTowers.xml.gz", FileMode.Open, FileAccess.Read))
            using (GZipStream zs = new GZipStream(s, CompressionMode.Decompress))
            {
                settings.controlTowerTypes = ControlTowerTypes.Load(zs);
            }
            Debug.WriteLine("Control Towers Types Finished Loading At: " + Program.stopWatch.Elapsed);

            using (FileStream s = new FileStream(Application.StartupPath + @"\data\mapData.xml.gz", FileMode.Open, FileAccess.Read))
            using (GZipStream zs = new GZipStream(s, CompressionMode.Decompress))
            {
                settings.mapData = MapData.Load(zs);
            }
            Debug.WriteLine("Map Data Finished Loading At: " + Program.stopWatch.Elapsed);

            using (FileStream s = new FileStream(Application.StartupPath + @"\data\moonData.xml.gz", FileMode.Open, FileAccess.Read))
            using (GZipStream zs = new GZipStream(s, CompressionMode.Decompress))
            {
                settings.moonData = MoonData.Load(zs);
            }
            Debug.WriteLine("Moon Data Finished Loading At: " + Program.stopWatch.Elapsed);

            if (File.Exists("Starbases.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Starbase>));
                using (Stream s = new FileStream("Starbases.xml", FileMode.Open))
                {
                    try
                    {
                        settings.availableStarBases = serializer.Deserialize(s) as List<Starbase>;
                    }
                    catch
                    {

                    }
                }
            }

            settings.accountInfo = AccountInfo.LoadFrom(settings.SerializedAccountInfoFilename);
            settings.starbaseList = StarbaseList.LoadStarbaseListFrom(settings.SerializeStarbaseListFilename);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
        }


    }
}