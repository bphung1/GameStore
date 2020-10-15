using System;
using System.Collections.Generic;

namespace GameStore.DataAccess.Entities
{
    public partial class Game
    {
        public Game()
        {
            GameOrder = new HashSet<GameOrder>();
            ItemInventory = new HashSet<ItemInventory>();
        }

        public int GameId { get; set; }
        public string GameName { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<GameOrder> GameOrder { get; set; }
        public virtual ICollection<ItemInventory> ItemInventory { get; set; }
    }
}
