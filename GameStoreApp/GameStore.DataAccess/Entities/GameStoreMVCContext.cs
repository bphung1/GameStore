using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GameStore.DataAccess.Entities
{
    public partial class GameStoreMVCContext : DbContext
    {
        public GameStoreMVCContext()
        {
        }

        public GameStoreMVCContext(DbContextOptions<GameStoreMVCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameOrder> GameOrder { get; set; }
        public virtual DbSet<ItemInventory> ItemInventory { get; set; }
        public virtual DbSet<StoreLocation> StoreLocation { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DefaultLocation)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.GameName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(16, 2)")
                    .HasDefaultValueSql("((0.00))");
            });

            modelBuilder.Entity<GameOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_OrderID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.GameOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameOrder)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameID");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.GameOrder)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreID");
            });

            modelBuilder.Entity<ItemInventory>(entity =>
            {
                entity.HasKey(e => e.InventoryId)
                    .HasName("PK_InventoryID");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.ItemInventory)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameIDInventory");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ItemInventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreIDInventory");
            });

            modelBuilder.Entity<StoreLocation>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK_StoreID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
