﻿using System;
using System.Collections.Generic;

namespace GameStore.DataAccess.Entities
{
    public partial class ItemInventory
    {
        public int InventoryId { get; set; }
        public int StoreId { get; set; }
        public int GameId { get; set; }
        public int? Quantity { get; set; }

        public virtual Game Game { get; set; }
        public virtual StoreLocation Store { get; set; }
    }
}
