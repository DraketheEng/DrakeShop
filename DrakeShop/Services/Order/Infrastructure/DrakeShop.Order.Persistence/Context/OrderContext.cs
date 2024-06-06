using DrakeShop.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrakeShop.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Ordering> Orderings { get; set; }
    }
}
