using System;
using System.Collections.Generic;

namespace pizzaCubeApi.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            Orders = new HashSet<Order>();
        }

        public int PizzaId { get; set; }
        public string PizzaName { get; set; } = null!;
        public string? PizzaType { get; set; }
        public string? PizzaSpecialty { get; set; }
        public string? PizzaCrust { get; set; }
        public string? PizzaPrice { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
