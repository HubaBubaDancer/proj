using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using proj.Models;

namespace proj.Data
{
    public class ApplicationDbContext : DbContext
    {
        
        public DbSet<ProductsNOM> ProductsNOMs { get; set; } = default!;
        public DbSet<Provider> Providers { get; set; } = default!;
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Product> Products { get; set; }


        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductsNOM>();
            modelBuilder.Entity<Provider>();
            modelBuilder.Entity<Stock>();
            modelBuilder.Entity<Product>()
                .HasOne<Stock>();
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        { }

        
    }
}