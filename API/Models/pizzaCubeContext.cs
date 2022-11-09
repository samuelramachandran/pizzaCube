using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pizzaCubeApi.Models
{
    public partial class pizzaCubeContext : DbContext
    {
        public pizzaCubeContext()
        {
        }

        public pizzaCubeContext(DbContextOptions<pizzaCubeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Pizza> Pizzas { get; set; } = null!;
        public virtual DbSet<PizzaCrust> PizzaCrusts { get; set; } = null!;
        public virtual DbSet<PizzaTopping> PizzaToppings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-FOT9996;Database=pizzaCube;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.DeliveryAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("deliveryAddress");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.CrustId).HasColumnName("crustID");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.NoOfSlices).HasColumnName("noOfSlices");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("orderDate");

                entity.Property(e => e.OrderNumber).HasColumnName("orderNumber");

                entity.Property(e => e.PaymentId).HasColumnName("paymentID");

                entity.Property(e => e.PizzaId).HasColumnName("pizzaID");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.ToppingsId).HasColumnName("toppingsID");

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CrustId)
                    .HasConstraintName("FK__orders__crustID__3B75D760");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__orders__customer__38996AB5");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__orders__paymentI__3A81B327");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK__orders__pizzaID__398D8EEE");

                entity.HasOne(d => d.Toppings)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ToppingsId)
                    .HasConstraintName("FK__orders__toppings__3C69FB99");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payments");

                entity.Property(e => e.PaymentId).HasColumnName("paymentID");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cardNumber");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cvv");

                entity.Property(e => e.ExpDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("expDate");

                entity.Property(e => e.ExpMonth)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("expMonth");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("transactionID");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("pizza");

                entity.Property(e => e.PizzaId).HasColumnName("pizzaID");

                entity.Property(e => e.PizzaCrust)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pizzaCrust");

                entity.Property(e => e.PizzaName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pizzaName");

                entity.Property(e => e.PizzaPrice)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pizzaPrice");

                entity.Property(e => e.PizzaSpecialty)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pizzaSpecialty");

                entity.Property(e => e.PizzaType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pizzaType");
            });

            modelBuilder.Entity<PizzaCrust>(entity =>
            {
                entity.HasKey(e => e.CrustId)
                    .HasName("PK__pizzaCru__C583F8F10DDD2080");

                entity.ToTable("pizzaCrust");

                entity.Property(e => e.CrustId).HasColumnName("crustID");

                entity.Property(e => e.CrustName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("crustName");
            });

            modelBuilder.Entity<PizzaTopping>(entity =>
            {
                entity.HasKey(e => e.ToppingsId)
                    .HasName("PK__pizzaTop__311AC244271D69B9");

                entity.ToTable("pizzaToppings");

                entity.Property(e => e.ToppingsId).HasColumnName("toppingsID");

                entity.Property(e => e.ToppingsName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("toppingsName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
