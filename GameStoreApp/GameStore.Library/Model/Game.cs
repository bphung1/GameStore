using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Library.Interface
{
    class Game
    {
        private string _gameName;
        private decimal _price;

        public int GameID { get; set; }

        public string GameName
        {
            get => _gameName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Game name must not be empty", nameof(value));
                }
                _gameName = value;
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
            }
        }

    }
}
