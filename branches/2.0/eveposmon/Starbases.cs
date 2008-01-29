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

    public partial class Starbases
    {
        public event AddedStarbaseEventHandler AddedStarbase;
        public event RemovedStarbaseEventHandler RemovedStarbase;

        public List<MonitoredStarbase> MonitoredStarbaseList = new List<MonitoredStarbase>();

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
                MonitoredStarbase starbase = GetMonitoredStarbaseById(displayStarbaseListItem.ItemId);

                // Starbase is not currently monitored and user has checked "monitor" so add it
                if (starbase == null && displayStarbaseListItem.Monitored == true)
                {
                    Accounts.Account account = displayStarbaseListItem.Account;
                    StarbaseDetail starbaseDetail = EveApi.GetStarbaseDetail(account.UserId, account.CharacterId, account.ApiKey, displayStarbaseListItem.ItemId);
                    AddStarbase(new MonitoredStarbase(displayStarbaseListItem.StarbaseListItem, starbaseDetail));
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
        public MonitoredStarbase GetMonitoredStarbaseById(int itemId)
        {
            foreach (MonitoredStarbase starbase in MonitoredStarbaseList)
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
            Settings.Save(Settings.SettingsFile);
        }

        public void AddStarbase(MonitoredStarbase starbase)
        {
            MonitoredStarbaseList.Add(starbase);
            OnAddedStarbase(new StarbaseEventArgs(starbase));
        }

        public void RemoveStarbase(MonitoredStarbase starbase)
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

        public class StarbaseEventArgs : EventArgs
        {
            public MonitoredStarbase Starbase;

            public StarbaseEventArgs(MonitoredStarbase starbase)
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
