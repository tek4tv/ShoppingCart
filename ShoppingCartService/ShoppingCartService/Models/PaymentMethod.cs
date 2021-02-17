using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShoppingCartService.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            OrderPayments = new HashSet<OrderPayment>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(100)]
        public string PaymentName { get; set; }
        [Column("enable")]
        public int? Enable { get; set; }

        [InverseProperty(nameof(OrderPayment.Payment))]
        public virtual ICollection<OrderPayment> OrderPayments { get; set; }
    }
}
