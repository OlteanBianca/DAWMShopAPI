using Microsoft.EntityFrameworkCore;
using ShopAPI.Models;

namespace ShopAPI
{
    public partial class AppDBContext : DbContext
    {
        public virtual DbSet<Inventory> Inventories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Shop> Shops { get; set; }


        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");
                entity.Property(e => e.ShopId).HasColumnName("Shop_Id");

                entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Product");

                entity.HasOne(d => d.Shop).WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Shop");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("Shop");

                entity.Property(e => e.Address).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}