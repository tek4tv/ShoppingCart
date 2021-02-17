using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShoppingCartService.Models
{
    [Table("OrderPayment")]
    public partial class OrderPayment
    {
        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Key]
        [Column("PaymentID")]
        public int PaymentId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderPayments")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(PaymentId))]
        [InverseProperty(nameof(PaymentMethod.OrderPayments))]
        public virtual PaymentMethod Payment { get; set; }
    }
}
