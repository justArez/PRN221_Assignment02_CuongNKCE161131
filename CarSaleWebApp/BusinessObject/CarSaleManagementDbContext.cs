using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObject;

public partial class CarSaleManagementDbContext : DbContext
{
    public CarSaleManagementDbContext()
    {
    }

    public CarSaleManagementDbContext(DbContextOptions<CarSaleManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());
        

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

        return strConn;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.ToTable("car");

            entity.Property(e => e.Carid)
                .HasMaxLength(32)
                .HasColumnName("carid");
            entity.Property(e => e.Carname)
                .HasMaxLength(100)
                .HasColumnName("carname");
            entity.Property(e => e.ManufacturerId)
                .HasMaxLength(32)
                .HasColumnName("manufacturer_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(12, 4)")
                .HasColumnName("price");
            entity.Property(e => e.PublishDate).HasColumnName("publish_date");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(8, 0)")
                .HasColumnName("quantity");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_car_manufacturer");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.ToTable("invoice");

            entity.Property(e => e.Invoiceid)
                .HasMaxLength(32)
                .HasColumnName("invoiceid");
            entity.Property(e => e.Carid)
                .HasMaxLength(32)
                .HasColumnName("carid");
            entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date");
            entity.Property(e => e.TotalCharge)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("total_charge");
            entity.Property(e => e.Userid)
                .HasMaxLength(32)
                .HasColumnName("userid");

            entity.HasOne(d => d.Car).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Carid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_invoice_car");

            entity.HasOne(d => d.User).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_invoice_user");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.ToTable("manufacturer");

            entity.Property(e => e.ManufacturerId)
                .HasMaxLength(32)
                .HasColumnName("manufacturer_id");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(100)
                .HasColumnName("manufacturer_name");
            entity.Property(e => e.ManufacturerSaleCount)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("manufacturer_sale_count");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("role");

            entity.Property(e => e.Roleid)
                .HasMaxLength(2)
                .HasColumnName("roleid");
            entity.Property(e => e.Rolename)
                .HasMaxLength(16)
                .HasColumnName("rolename");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK_user_1");

            entity.ToTable("user");

            entity.Property(e => e.Userid)
                .HasMaxLength(32)
                .HasColumnName("userid");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.Roleid)
                .HasMaxLength(2)
                .HasColumnName("roleid");
            entity.Property(e => e.Username)
                .HasMaxLength(40)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
