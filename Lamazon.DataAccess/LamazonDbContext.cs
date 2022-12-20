using Lamazon.DomainModels.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection;

namespace Lamazon.DataAccess
{
    //Microsoft.EntityFrameworkCore
    //Microsoft.EntityFrameworkCore.Design
    //Microsoft.EntityFrameworkCore.SqlServer
    //Microsoft.EntityFrameworkCore.Tools
    public class LamazonDbContext : DbContext
    {
        public LamazonDbContext(DbContextOptions options) : base(options) 
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLineItem> OrderLineItem { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
