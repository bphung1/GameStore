using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.WebUI.Models
{
    public class StoreLocationViewModel
    {
        [Display(Name = "Store Id")]
        public int StoreID { get; set; }

        [Display(Name = "Store Name")]
        public string StoreName { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }
    }
}
