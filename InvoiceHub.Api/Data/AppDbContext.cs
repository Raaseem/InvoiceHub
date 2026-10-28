using InvoiceHub.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InvoiceHub.Api.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Invoice> Invoices => Set<Invoice>();
        public DbSet<Customer> Customers => Set<Customer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>(e =>
            {
                e.HasIndex(x => x.InvoiceNumber).IsUnique();
                e.Property(x => x.InvoiceNumber).HasMaxLength(50).IsRequired();
                e.Property(x => x.CustomerName).HasMaxLength(200).IsRequired();
                e.Property(x => x.Status).HasMaxLength(20);
                e.Property(x => x.Subtotal).HasPrecision(18, 2);
                e.Property(x => x.VatAmount).HasPrecision(18, 2);
                e.Property(x => x.Total).HasPrecision(18, 2);
            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.Property(x => x.Name).HasMaxLength(200).IsRequired();
                e.Property(x => x.Email).HasMaxLength(200);
                e.Property(x => x.Phone).HasMaxLength(30);
                e.Property(x => x.TaxRegistrationNumber).HasMaxLength(50);
                e.HasIndex(x => x.Email);
            });
        }
    }
}
