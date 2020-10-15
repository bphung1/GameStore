using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Library.Model
{
    public class GameOrder
    {
        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public int StoreID { get; set; }

        public int GameID { get; set; }

        public DateTime OrderTime { get; set; }

        public int Quantity { get; set; }

        public Game Game { get; set; }

        public StoreLocation Store { get; set; }
    }
}
