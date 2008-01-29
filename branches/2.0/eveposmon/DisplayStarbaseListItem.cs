using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using libeveapi;
using eveposmon.StaticData;

namespace eveposmon
{
    public class DisplayStarbaseListItem
    {
        private bool monitored;
        private Accounts.Account account;
        StarbaseList.StarbaseListItem starbaseListItem;

        public DisplayStarbaseListItem(bool monitored, Accounts.Account account, StarbaseList.StarbaseListItem starbaseListItem)
        {
            this.monitored = monitored;
            this.account = account;
            this.starbaseListItem = starbaseListItem;
        }

        public int ItemId
        {
            get { return starbaseListItem.ItemId; }
        }

        public bool Monitored
        {
            get { return monitored; }
            set { monitored = value; }
        }

        public string Region
        {
            get
            {
                SolarSystems.SolarSystem solarSystem = SolarSystems.GetSolarSystemById(starbaseListItem.LocationId);
                Regions.Region region = Regions.GetRegionById(solarSystem.RegionId);
                return region.Name;
            }
        }

        public string Constellation
        {
            get
            {
                SolarSystems.SolarSystem solarSystem = SolarSystems.GetSolarSystemById(starbaseListItem.LocationId);
                Constellations.Constellation constellation = Constellations.GetConstellationById(solarSystem.ConstellationId);
                return constellation.Name;
            }
        }

        public string Moon
        {
            get
            {
                Moons.Moon moon = Moons.GetMoonById(starbaseListItem.MoonId);
                return moon.Name;
            }
        }

        public string Status
        {
            get
            {
                return starbaseListItem.State.ToString();
            }
        }

        public string StarbaseType
        {
            get
            {
                Towers.Tower tower = Towers.GetTowerByTypeId(starbaseListItem.TypeId);
                return tower.TypeName;
            }
        }

        public Accounts.Account Account
        {
            get { return account; }
        }

        public string AccountName
        {
            get { return account.CharacterName; }
        }

        public StarbaseList.StarbaseListItem StarbaseListItem
        {
            get { return starbaseListItem; }

        }
    }
}
