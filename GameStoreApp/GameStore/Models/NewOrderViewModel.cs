using GameStore.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.WebUI.Models
{
    public class NewOrderViewModel
    {
        [Display(Name = "Order Id")]
        public int OrderID { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }


        [Display(Name = "Store")]
        public int StoreId { get; set; }

        public StoreLocation StoreLocation { get; set; }


        [Display(Name = "List Of Games")]
        public IEnumerable<Game> ListOfGames { get; set; }

        public Game Game { get; set; }


        [Display(Name = "Quantity")]
        public IEnumerable<int> ChooseQuantity { get; set; }
    }
}
