using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShoppingCartService.Models
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Invoices = new HashSet<Invoice>();
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [InverseProperty(nameof(Address.User))]
        public virtual ICollection<Address> Addresses { get; set; }
        [InverseProperty(nameof(Invoice.User))]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [InverseProperty(nameof(Order.User))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
