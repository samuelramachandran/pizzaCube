using System;
using System.Collections.Generic;

namespace pizzaCubeApi.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? DeliveryAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
