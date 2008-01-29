using System;
using System.Collections.Generic;
using System.Text;

using libeveapi;
using eveposmon.StaticData;

namespace eveposmon
{
    public partial class Starbases
    {
        public class MonitoredStarbase
        {
            private readonly int strontiumTypeId = 16275;

            public StarbaseList.StarbaseListItem StarbaseListItem;
            public StarbaseDetail StarbaseDetail;

            public StarbaseDetail.FuelListItem[] FuelList = null;

            public MonitoredStarbase()
            {

            }

            public MonitoredStarbase(StarbaseList.StarbaseListItem starbaseListItem, StarbaseDetail starbaseDetail)
            {
                this.StarbaseListItem = starbaseListItem;
                this.StarbaseDetail = starbaseDetail;
            }

            public int ItemId
            {
                get { return StarbaseListItem.ItemId; }
            }

            public string TypeName
            {
                get
                {
                    Towers.Tower tower = Towers.GetTowerByTypeId(StarbaseListItem.TypeId);
                    return tower.TypeName;
                }
            }

            public string MoonName
            {
                get
                {
                    Moons.Moon moon = Moons.GetMoonById(StarbaseListItem.MoonId);
                    return moon.Name;
                }
            }

            public StarbaseDetail.FuelListItem[] Fuels
            {
                get
                {
                    if (FuelList == null)
                    {
                        return StarbaseDetail.FuelList;
                    }

                    return FuelList;
                }
            }

            public int StrontiumCapacity
            {
                get
                {
                    Towers.Tower tower = Towers.GetTowerByTypeId(StarbaseListItem.TypeId);
                    switch (tower.Volume)
                    {
                        case 2000:
                            return 12500;
                        case 4000:
                            return 25000;
                        case 8000:
                            return 50000;
                        default:
                            return -1;
                    }
                }
            }

            public int FuelCapacity
            {
                get
                {
                    Towers.Tower tower = Towers.GetTowerByTypeId(StarbaseListItem.TypeId);
                    return tower.Capacity;
                }
            }

            public double TotalStrontiumVolume
            {
                get
                {
                    foreach (StarbaseDetail.FuelListItem fuelListItem in Fuels)
                    {
                        if (fuelListItem.TypeId == strontiumTypeId)
                        {
                            StaticData.Fuels.Fuel fuel = StaticData.Fuels.GetFuelByTypeId(strontiumTypeId);
                            return fuelListItem.Quantity * fuel.Volume;
                        }
                    }
                    return 0;
                }
            }

            public double TotalFuelVolume
            {
                get
                {
                    double total = 0.0;
                    foreach (StarbaseDetail.FuelListItem fuelListItem in Fuels)
                    {
                        if (fuelListItem.TypeId != strontiumTypeId)
                        {
                            double volume = StaticData.Fuels.GetFuelByTypeId(fuelListItem.TypeId).Volume;
                            total += fuelListItem.Quantity * volume;
                        }
                    }
                    return total;
                }
            }
        }
    }
}
