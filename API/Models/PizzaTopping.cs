using System;
using System.Collections.Generic;

namespace pizzaCubeApi.Models
{
    public partial class PizzaTopping
    {
        public PizzaTopping()
        {
            Orders = new HashSet<Order>();
        }

        public int ToppingsId { get; set; }
        public string? ToppingsName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
