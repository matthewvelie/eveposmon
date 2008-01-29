using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using libeveapi;
using eveposmon.StaticData;

namespace eveposmon
{
    public delegate void AddedStarbaseEventHandler(object sender, Starbases.StarbaseEventArgs e);
    public delegate void RemovedStarbaseEventHandler(object sender, Starbases.StarbaseEventArgs e);
    public delegate void SelectStarbasesEventHandler(object sender, Starbases.SelectStarbasesEventArgs e);

    public class Starbases
    {
        public event AddedStarbaseEventHandler AddedStarbase;
        public event RemovedStarbaseEventHandler RemovedStarbase;

        public List<Starbase> MonitoredStarbaseList = new List<Starbase>();

        /// <summary>
        /// Go through all the possible starbases we could monitor
        /// If the user checked monitor and we aren't currently monitoring then add
        /// If the user unchecked monitor and we are currently monitoring then remove
        /// </summary>
        /// <param name="displayStarbaseListItems"></param>
        public void UpdateStarbaseList(BindingList<DisplayStarbaseListItem> displayStarbaseListItems)
        {
            foreach (DisplayStarbaseListItem displayStarbaseListItem in displayStarbaseListItems)
            {
                // Search the list of monitored starbases for the current starbase
                Starbase starbase = GetMonitoredStarbaseById(displayStarbaseListItem.ItemId);

                // Starbase is not currently monitored and user has checked "monitor" so add it
                if (starbase == null && displayStarbaseListItem.Monitored == true)
                {
                    Accounts.Account account = displayStarbaseListItem.Account;
                    StarbaseDetail starbaseDetail = EveApi.GetStarbaseDetail(account.UserId, account.CharacterId, account.ApiKey, displayStarbaseListItem.ItemId);
                    AddStarbase(new Starbase(displayStarbaseListItem.StarbaseListItem, starbaseDetail));
                }

                // Starbase is currently monitored and user unchecked "monitor" so remove it
                if (starbase != null && displayStarbaseListItem.Monitored == false)
                {
                    RemoveStarbase(starbase);
                }
            }
        }

        /// <summary>
        /// Search the monitored starbase list and return the starbase with the 
        /// specified id or null if not found
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Starbase GetMonitoredStarbaseById(int itemId)
        {
            foreach (Starbase starbase in MonitoredStarbaseList)
            {
                if (itemId == starbase.ItemId)
                {
                    return starbase;
                }
            }

            return null;
        }

        public void SelectStarbases(object sender, SelectStarbasesEventArgs e)
        {
            UpdateStarbaseList(e.DisplayStarbaseListItems);
        }

        public void AddStarbase(Starbase starbase)
        {
            MonitoredStarbaseList.Add(starbase);
            OnAddedStarbase(new StarbaseEventArgs(starbase));
        }

        public void RemoveStarbase(Starbase starbase)
        {
            MonitoredStarbaseList.Remove(starbase);
            OnRemovedStarbase(new StarbaseEventArgs(starbase));
        }

        protected virtual void OnAddedStarbase(StarbaseEventArgs e)
        {
            if (AddedStarbase != null)
            {
                AddedStarbase(this, e);
            }
        }

        protected virtual void OnRemovedStarbase(StarbaseEventArgs e)
        {
            if (RemovedStarbase != null)
            {
                RemovedStarbase(this, e);
            }
        }

        public class Starbase
        {
            private StarbaseList.StarbaseListItem starbaseListItem;
            private StarbaseDetail starbaseDetail;

            public Starbase()
            {

            }

            public Starbase(StarbaseList.StarbaseListItem starbaseListItem, StarbaseDetail starbaseDetail)
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

        public class StarbaseEventArgs : EventArgs
        {
            public Starbase Starbase;

            public StarbaseEventArgs(Starbase starbase)
            {
                this.Starbase = starbase;
            }
        }

        public class SelectStarbasesEventArgs : EventArgs
        {
            public BindingList<DisplayStarbaseListItem> DisplayStarbaseListItems;

            public SelectStarbasesEventArgs(BindingList<DisplayStarbaseListItem> displayStarbaseListItems)
            {
                this.DisplayStarbaseListItems = displayStarbaseListItems;
            }
        }
    }
}
