using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Library.Interface
{
    class Customer
    {
        private string _firstName;
        private string _lastName;

        public int CustomerID { get; set; }
        public string FirstName {
            get => _firstName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("First name must not be empty.", nameof(value));
                }
                _firstName = value;
            }
        }
    }
}
