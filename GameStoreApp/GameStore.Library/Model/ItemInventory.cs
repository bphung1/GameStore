using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Library.Model
{
    public class ItemInventory
    {
        public int InventoryID { get; set; }

        public int StoreID { get; set; }

        public int GameID { get; set; }

        public int Quantity { get; set; }

        public Game Game { get; set; }

        public StoreLocation StoreLocation { get; set; }
    }
}
