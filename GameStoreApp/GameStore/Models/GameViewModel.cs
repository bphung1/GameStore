using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.WebUI.Models
{
    public class GameViewModel
    {
        [Display(Name = "Game ID")]
        public int GameID { get; set; }

        [Display(Name = "Game Name")]
        public string GameName { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }
    }
}
