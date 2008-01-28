using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

using libeveapi;
using eveposmon.StaticData;

namespace eveposmon
{
    public partial class SelectStarbases : Form
    {
        BindingList<DisplayStarbaseListItem> displayStarbaseListItems = new BindingList<DisplayStarbaseListItem>();

        public SelectStarbases()
        {
            InitializeComponent();

            createDisplayStarbaseItemsList();
            dgvStarbaseList.AutoGenerateColumns = false;
            dgvStarbaseList.DataSource = displayStarbaseListItems;
        }

        private void createDisplayStarbaseItemsList()
        {
            
            foreach (Accounts.Account account in Settings.Instance.Accounts.AccountList)
            {
                StarbaseList starbaseList = EveApi.GetStarbaseList(account.UserId, account.CharacterId, account.ApiKey);
                foreach (StarbaseList.StarbaseListItem starbaseListItem in starbaseList.StarbaseListItems)
                {
                    displayStarbaseListItems.Add(new DisplayStarbaseListItem(false, account, starbaseListItem));
                }
            }
        }

        private void dgvStarbaseList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStarbaseList.Columns[e.ColumnIndex].HeaderText == "Monitor")
            {
                displayStarbaseListItems[e.RowIndex].Monitored = !displayStarbaseListItems[e.RowIndex].Monitored;
            }
        }

        public BindingList<DisplayStarbaseListItem> DisplayStarbaseListItems
        {
            get { return displayStarbaseListItems; }
        }
    }
}