using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShoppingCartService.Models
{
    public partial class Order
    {
        public Order()
        {
            Invoices = new HashSet<Invoice>();
            OrderPayments = new HashSet<OrderPayment>();
            OrderProducts = new HashSet<OrderProduct>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        public int? DeliveryAddress { get; set; }
        public int? BillingAddress { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "date")]
        public DateTime? OrderCreated { get; set; }
        [Column(TypeName = "date")]
        public DateTime? OrderCheckout { get; set; }
        [Column(TypeName = "date")]
        public DateTime? OrderCompleted { get; set; }
        public double? Subtotal { get; set; }
        public double? Total { get; set; }

        [ForeignKey(nameof(BillingAddress))]
        [InverseProperty(nameof(Address.OrderBillingAddressNavigations))]
        public virtual Address BillingAddressNavigation { get; set; }
        [ForeignKey(nameof(DeliveryAddress))]
        [InverseProperty(nameof(Address.OrderDeliveryAddressNavigations))]
        public virtual Address DeliveryAddressNavigation { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Orders")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Invoice.Order))]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [InverseProperty(nameof(OrderPayment.Order))]
        public virtual ICollection<OrderPayment> OrderPayments { get; set; }
        [InverseProperty(nameof(OrderProduct.Order))]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
