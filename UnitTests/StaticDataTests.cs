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
        public void StationListTest()
        {
            StationList.LoadFromFile(@"..\..\..\data\staStations.xml.gz");

            Assert.AreEqual("Muvolailen X - Moon 3 - CBD Corporation Storage", StationList.GetStationNameById(60000004));
            Assert.AreEqual(null, StationList.GetStationNameById(1));

            StationList.Station station = StationList.GetStationById(60000007);
            Assert.AreEqual("Ono V - Moon 9 - CBD Corporation Storage", station.Name);
            Assert.AreEqual(null, StationList.GetStationById(1));
        }
    }
}
