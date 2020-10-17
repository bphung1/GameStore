using GameStore.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.WebUI.Models
{
    public class GameOrderViewModel
    {
        [Display(Name = "Order Id")]
        public int OrderID { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Store")]
        public int StoreId { get; set; }

        public StoreLocation StoreLocation { get; set; }

        [Display(Name = "Order Time")]
        public DateTime OrderTime { get; set; }



        public List<int> GameIds = new List<int>();

        [Display(Name = "List Of Games")]
        public IEnumerable<Game> ListOfGames { get; set; }

        public Game Game { get; set; }


        [Display(Name = "Quantity")]
        public IEnumerable<int> ChooseQuantity { get; set; }

        public int Quantity { get; set; }

        public List<int> QuantityList { get; set; }

        public int GameID { get; set; }
    }
}
