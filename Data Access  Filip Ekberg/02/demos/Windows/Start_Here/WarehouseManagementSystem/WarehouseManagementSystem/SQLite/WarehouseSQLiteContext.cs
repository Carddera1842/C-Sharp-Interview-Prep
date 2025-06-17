using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Warehouse.Data.SQLite;

public partial class WarehouseSQLiteContext : DbContext
{
    public WarehouseSQLiteContext()
    {
    }

    public WarehouseSQLiteContext(DbContextOptions<WarehouseSQLiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemWarehouse> ItemWarehouses { get; set; }

    public virtual DbSet<LineItem> LineItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<ShippingProvider> ShippingProviders { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("data source=C:\\Users\\admin\\Desktop\\C-Sharp-Interview-Prep\\Data Access  Filip Ekberg\\02\\demos\\Windows\\Start_Here\\WarehouseManagementSystem\\WarehouseManagementSystem\\warehouse.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<ItemWarehouse>(entity =>
        {
            entity.HasKey(e => new { e.ItemsId, e.WarehousesId });

            entity.ToTable("ItemWarehouse");

            entity.HasOne(d => d.Warehouses).WithMany(p => p.ItemWarehouses)
                .HasForeignKey(d => d.WarehousesId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<LineItem>(entity =>
        {
            entity.ToTable("LineItem");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId");

            entity.HasIndex(e => e.ShippingProviderId, "IX_Orders_ShippingProviderId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasForeignKey(d => d.CustomerId);

            entity.HasOne(d => d.ShippingProvider).WithMany(p => p.Orders).HasForeignKey(d => d.ShippingProviderId);
        });

        modelBuilder.Entity<ShippingProvider>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.ToTable("Warehouse");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
