using System;
using System.Collections.Generic;
using System.Text;

using eveposmon.StaticData;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class StaticDataTests
    {
        [Test]
        public void StationsTest()
        {
            Stations.LoadFromFile(@"..\..\..\data\staStations.xml.gz");

            Stations.Station station = Stations.GetStationById(60000007);
            Assert.AreEqual("Ono V - Moon 9 - CBD Corporation Storage", station.Name);
            Assert.AreEqual(null, Stations.GetStationById(1));
        }

        [Test]
        public void ConstellationsTest()
        {
            Constellations.LoadFromFile(@"..\..\..\data\Constellations.xml.gz");
            Assert.AreEqual(null, Constellations.GetConstellationById(0));
        }
    }
}
