using System;
using System.Collections.Generic;

namespace pizzaCubeApi.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string? TransactionId { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpDate { get; set; }
        public string? ExpMonth { get; set; }
        public string? Cvv { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
