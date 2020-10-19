using System;
using System.Collections.Generic;

namespace GameStore.DataAccess.Entities
{
    public partial class StoreLocation
    {
        public StoreLocation()
        {
            GameOrder = new HashSet<GameOrder>();
            ItemInventory = new HashSet<ItemInventory>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<GameOrder> GameOrder { get; set; }
        public virtual ICollection<ItemInventory> ItemInventory { get; set; }
    }
}
