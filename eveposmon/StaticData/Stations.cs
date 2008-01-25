using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace eveposmon.StaticData
{
    public class Stations
    {
        private static Hashtable stationTable = new Hashtable();

        /// <summary>
        /// Load the static station data from a gzip compressed xml file
        /// </summary>
        /// <param name="file">path to the file</param>
        public static void LoadFromFile(string file)
        {
            using (FileStream s = new FileStream(file, FileMode.Open))
            using (GZipStream gz = new GZipStream(s, CompressionMode.Decompress))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(gz);

                foreach (XmlNode stationNode in doc.SelectNodes("/stations/station"))
                {
                    Station station = new Station();
                    station.Id = Convert.ToInt32(stationNode.Attributes["stationID"].InnerText);
                    station.Name = stationNode.Attributes["stationName"].InnerText;
                    stationTable.Add(station.Id, station);
                }
            }
        }

        /// <summary>
        /// Get a station object by stationId
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        public static Station GetStationById(int stationId)
        {
            if (stationTable.Contains(stationId))
            {
                return stationTable[stationId] as Station;
            }

            return null;
        }

        /// <summary>
        /// Represents static data about a single station
        /// </summary>
        public class Station
        {
            /// <summary>
            /// The unique identifier for this station
            /// </summary>
            public int Id;

            /// <summary>
            /// The full name of the station
            /// </summary>
            public string Name;
        }
    }
}
