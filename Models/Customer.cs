using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pizzaCube.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Name is Required")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is Required")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string? DeliveryAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
