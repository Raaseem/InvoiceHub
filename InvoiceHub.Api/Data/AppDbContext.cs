using InvoiceHub.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceHub.Api.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Invoice> Invoices => Set<Invoice>();

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
        }
    }
}
