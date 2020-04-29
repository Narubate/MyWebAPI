using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

namespace MyWebAPI.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // ใช้สำหรับ Custom database

            // Naming convertion snake case
            modelBuilder.Entity<Product>().ToTable("cm_product");

            modelBuilder.Entity<Product>(b =>
            {
                b.Property(p => p.Name).HasColumnName("product_name");
            });

            // Default Value
            modelBuilder.Entity<Product>(b =>
            {
                b.Property(p => p.Name).HasDefaultValue("unknows");
            });

            // Data type
            modelBuilder.Entity<Product>(b =>
            {
                b.Property(p => p.Name).HasColumnType("varchar(200)");
                b.Property(p => p.Price).HasColumnType("varchar(200)");
            });
        }
    }
}