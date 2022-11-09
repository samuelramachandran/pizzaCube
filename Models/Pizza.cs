using System;
using System.Collections.Generic;

namespace pizzaCube.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            Orders = new HashSet<Order>();
        }

        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public string? PizzaType { get; set; }
        public string? PizzaSpecialty { get; set; }
        public string? PizzaCrust { get; set; }
        public string? PizzaPrice { get; set; }

        public int CrustId { get; set; }
        public string? CrustName { get; set; }

        public int ToppingsId { get; set; }
        public string? ToppingsName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
