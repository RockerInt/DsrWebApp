using Microsoft.EntityFrameworkCore;  
using WebApp.Domain.Entities; 

namespace WebApp.Infrastructure;

/// <summary>
/// Represents the application database context, responsible for managing entity configurations and database sessions.
/// </summary>
/// <param name="options"></param>
public partial class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Applies entity configurations from the containing assembly.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Client>(b =>
        {
            b.HasKey(c => c.Id);
            b.Property(c => c.Name).IsRequired().HasMaxLength(200);
            b.Property(c => c.Email).IsRequired().HasMaxLength(100);
            b.Property(c => c.Phone).IsRequired().HasMaxLength(20);
        });
        modelBuilder.Entity<Product>(b =>
        {
            b.HasKey(p => p.Id);
            b.Property(p => p.Name).IsRequired().HasMaxLength(200);
            b.Property(p => p.Description).HasMaxLength(500);
            b.Property(p => p.Price).HasColumnType("decimal(18,2)");
        });
        modelBuilder.Entity<Inventory>(b =>
        {
            b.HasKey(i => i.Id);
            b.Property(i => i.StockQuantity).IsRequired();
            b.HasOne(i => i.Product)
                .WithMany()
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<Sale>(b =>
        {
            b.HasKey(s => s.Id);
            b.Property(s => s.SaleDate).IsRequired();
            b.HasOne(s => s.Client)
                .WithMany()
                .HasForeignKey(s => s.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<SaleItem>(b =>
        {
            b.HasKey(si => si.Id);
            b.Property(si => si.Quantity).IsRequired();
            b.Property(si => si.UnitPrice).HasColumnType("decimal(18,2)");
            b.HasOne(si => si.Product)
                .WithMany()
                .HasForeignKey(si => si.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Seed();
    }
}     