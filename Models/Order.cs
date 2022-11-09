using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pizzaCube.Models
{
    public partial class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [Display(Name = "Order Number")]
        public int OrderNumber { get; set; }
        [Required]
        public int? CustomerId { get; set; }
        [Required]
        public int? PizzaId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? OrderDate { get; set; }
        [Required]
        public int? PaymentId { get; set; }
        [Required(ErrorMessage = "Choose quantity between 1 and  15")]
        public int? Qty { get; set; }

        [Required(ErrorMessage = "Choose number slices is required")]
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
