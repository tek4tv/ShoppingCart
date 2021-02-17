using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShoppingCartService.Models
{
    public partial class Address
    {
        public Address()
        {
            OrderBillingAddressNavigations = new HashSet<Order>();
            OrderDeliveryAddressNavigations = new HashSet<Order>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        [StringLength(200)]
        public string Line1 { get; set; }
        [StringLength(200)]
        public string Line2 { get; set; }
        [StringLength(200)]
        public string Line3 { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Addresses")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Order.BillingAddressNavigation))]
        public virtual ICollection<Order> OrderBillingAddressNavigations { get; set; }
        [InverseProperty(nameof(Order.DeliveryAddressNavigation))]
        public virtual ICollection<Order> OrderDeliveryAddressNavigations { get; set; }
    }
}
