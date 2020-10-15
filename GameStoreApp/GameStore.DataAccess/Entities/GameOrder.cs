using System;
using System.Collections.Generic;

namespace GameStore.DataAccess.Entities
{
    public partial class GameOrder
    {
        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public int GameId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderTime { get; set; }
        public int? Quantity { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Game Game { get; set; }
        public virtual StoreLocation Store { get; set; }
    }
}
