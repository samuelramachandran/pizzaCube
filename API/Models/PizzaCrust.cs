using System;
using System.Collections.Generic;

namespace pizzaCubeApi.Models
{
    public partial class PizzaCrust
    {
        public PizzaCrust()
        {
            Orders = new HashSet<Order>();
        }

        public int CrustId { get; set; }
        public string? CrustName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
