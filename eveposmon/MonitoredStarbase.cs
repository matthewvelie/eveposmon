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
            public StarbaseList.StarbaseListItem StarbaseListItem;
            public StarbaseDetail StarbaseDetail;

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
        }
    }
}
