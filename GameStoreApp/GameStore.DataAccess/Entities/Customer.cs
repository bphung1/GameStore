using System;
using System.Collections.Generic;

namespace GameStore.DataAccess.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            GameOrder = new HashSet<GameOrder>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DefaultLocation { get; set; }

        public virtual ICollection<GameOrder> GameOrder { get; set; }
    }
}
