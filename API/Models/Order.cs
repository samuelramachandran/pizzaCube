using System;
using System.Collections.Generic;

namespace pizzaCubeApi.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public int? CustomerId { get; set; }
        public int? PizzaId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? PaymentId { get; set; }
        public int? Qty { get; set; }
        public int? NoOfSlices { get; set; }
        public int? CrustId { get; set; }
        public int? ToppingsId { get; set; }
        public string? Status { get; set; }

        public virtual PizzaCrust? Crust { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual Payment? Payment { get; set; }
        public virtual Pizza? Pizza { get; set; }
        public virtual PizzaTopping? Toppings { get; set; }
    }
}
