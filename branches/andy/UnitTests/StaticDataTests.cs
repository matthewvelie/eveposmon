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

        [Test]
        public void TowerResourcesTest()
        {
            TowerResources.LoadFromFile(@"..\..\..\data\controlTowerResources.xml.gz");

            TowerResources.Tower tower = TowerResources.GetByTypeId(12235);

            Assert.AreEqual(null, TowerResources.GetByTypeId(0));

            TowerResources.Fuel fuel = tower.FuelList[0];
            Assert.AreEqual(44, fuel.TypeId);
            Assert.AreEqual(1, fuel.purpose);
            Assert.AreEqual(4, fuel.Quantity);
            Assert.AreEqual(-1, fuel.Minsec);
            Assert.AreEqual(-1, fuel.faction);

            // fuel is required in all cases
            Assert.IsTrue(tower.RequiresFuel(44, 0.1, 500003));
            Assert.IsTrue(tower.RequiresFuel(44, 0.5, 500003));
            Assert.IsTrue(tower.RequiresFuel(44, 0.5, 500002));
            Assert.IsTrue(tower.RequiresFuel(44, 0.1, 500002));

            fuel = tower.FuelList[9];
            Assert.AreEqual(24592, fuel.TypeId);
            Assert.AreEqual(1, fuel.purpose);
            Assert.AreEqual(1, fuel.Quantity);
            Assert.AreEqual(0.4, fuel.Minsec);
            Assert.AreEqual(500003, fuel.faction);

            // faction matches and
            // security status below minsec so fuel not required
            Assert.IsFalse(tower.RequiresFuel(24592, 0.1, 500003));

            // faction matches and
            // security status above minsec so required
            Assert.IsTrue(tower.RequiresFuel(24592, 0.5, 500003));

            // security status above minsec and
            // faction doesn't match so fuel not required
            Assert.IsFalse(tower.RequiresFuel(24592, 0.5, 500002));

            // security status below minsec and
            // faction doesn't match so not required
            Assert.IsFalse(tower.RequiresFuel(24592, 0.1, 500002));
        }

        [Test]
        public void FactionTest()
        {
            Factions.LoadFromFile(@"..\..\..\data\factions.xml.gz");

            Assert.AreEqual(null, Factions.GetFactionById(0));

            Factions.Faction faction = Factions.GetFactionById(500001);
            Assert.AreEqual("Caldari State", faction.Name);
        }

        [Test]
        public void TowersTest()
        {
            Towers.LoadFromFile(@"..\..\..\data\invControlTowers.xml.gz");

            Assert.AreEqual(null, Towers.GetTowerByTypeId(0));

            Towers.Tower tower = Towers.GetTowerByTypeId(12235);
            Assert.AreEqual(12235, tower.TypeId);
            Assert.AreEqual("Amarr Control Tower", tower.TypeName);
            Assert.AreEqual(110000, tower.Capacity);
            Assert.AreEqual(Towers.RaceType.Amarr, tower.Race);
            Assert.AreEqual(8000, tower.Volume);
            Assert.IsTrue(tower.Description.StartsWith("The Amarr have always been fond of"));
        }

        [Test]
        public void FuelsTest()
        {
            Fuels.LoadFromFile(@"..\..\..\data\invFuelTypes.xml.gz");

            Assert.AreEqual(null, Fuels.GetFuelByTypeId(0));

            Fuels.Fuel fuel = Fuels.GetFuelByTypeId(44);
            Assert.AreEqual(44, fuel.TypeId);
            Assert.AreEqual(282, fuel.GroupId);
            Assert.AreEqual("Radioactive", fuel.GroupName);
            Assert.AreEqual(17, fuel.CategoryId);
            Assert.AreEqual("Commodity", fuel.CategoryName);
            Assert.AreEqual("Enriched Uranium", fuel.TypeName);
            Assert.AreEqual("icon06_06.png", fuel.Icon);
            Assert.AreEqual(2000, fuel.Mass);
            Assert.AreEqual(1, fuel.Volume);
            Assert.AreEqual(0, fuel.Capacity);
            Assert.IsTrue(fuel.Description.StartsWith("Enriched Uranium is used in many"));
        }

        [Test]
        public void MoonsTest()
        {
            Moons.LoadFromFile(@"..\..\..\data\moonData.xml.gz");

            Assert.AreEqual(null, Moons.GetMoonById(0));

            Moons.Moon moon = Moons.GetMoonById(40000004);
            Assert.AreEqual(moon.Id, 40000004);
            Assert.AreEqual(moon.Name, "Tanoo I - Moon 1");
        }
    }
}
