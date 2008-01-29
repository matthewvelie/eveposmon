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
            private StarbaseList.StarbaseListItem starbaseListItem;
            private StarbaseDetail starbaseDetail;

            public MonitoredStarbase()
            {

            }

            public MonitoredStarbase(StarbaseList.StarbaseListItem starbaseListItem, StarbaseDetail starbaseDetail)
            {
                this.starbaseListItem = starbaseListItem;
                this.starbaseDetail = starbaseDetail;
            }

            public int ItemId
            {
                get { return starbaseListItem.ItemId; }
            }

            public string TypeName
            {
                get
                {
                    Towers.Tower tower = Towers.GetTowerByTypeId(starbaseListItem.TypeId);
                    return tower.TypeName;
                }
            }
        }
    }
}
