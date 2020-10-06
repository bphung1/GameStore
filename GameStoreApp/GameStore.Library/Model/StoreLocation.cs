using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Library.Interface
{
    class StoreLocation
    {
        private string _storeName;
        private string _state;

        public int StoreID { get; set; }

        public string StoreName
        {
            get => _storeName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Store name must not be empty", nameof(value));
                }
                _storeName = value;
            }
        }

        public string State
        {
            get => _state;
            set 
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("State must not be empty", nameof (value));
                }
                _state = value;
            }
        }
    }
}
