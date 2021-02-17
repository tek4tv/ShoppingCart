using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShoppingCartService.Models
{
    [Table("Invoice")]
    public partial class Invoice
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("OrderID")]
        public int? OrderId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [Column(TypeName = "date")]
        public DateTime? InvoiceCreated { get; set; }
        public double? Subtotal { get; set; }
        public double? Total { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("Invoices")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Invoices")]
        public virtual User User { get; set; }
    }
}
