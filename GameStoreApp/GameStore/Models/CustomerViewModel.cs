using GameStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.WebUI.Models
{
    public class CustomerViewModel
    {
        [Display(Name = "ID")]
        public int CustomerId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Order Id")]
        public IEnumerable<GameOrder> ListOfGameOrder { get; set; }

        public IEnumerable<GameOrderViewModel> GameOrders { get; set; }
    }
}
