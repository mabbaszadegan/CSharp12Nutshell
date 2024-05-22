using CSharp12Nutshell.Chapter08.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp12Nutshell.Chapter08.EFCore
{
    public class NutshellDbContext : DbContext
    {
        public NutshellDbContext()
        {

        }

        public NutshellDbContext(DbContextOptions<NutshellDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                  .Entity<Customer>()
                  .ToTable("Customer");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity
                    .ToTable("Customer")
                    .HasKey(c => c.Id);

                entity
                    .Property(propertyExpression => propertyExpression.Name)
                    .IsRequired()                   // Column is not nullable
                    .HasColumnName("CustomerName"); // Column name is 'CustomerName'
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity
                    .ToTable("Product")
                    .HasData(new List<Product>
                    {
                        new Product {Id=1, Name="Asus Core i7", Category="Laptop", Description="", Price=450000, Quantity=5},
                        new Product {Id=2, Name="Asus Core i5", Category="Laptop", Description="", Price=350000, Quantity=15},
                        new Product {Id=3, Name="Sony Core i7", Category="Laptop", Description="", Price=470000, Quantity=7}
                    });

                entity
                    .Property(p => p.Id)
                    .ValueGeneratedOnAdd();

                entity
                    .Property(p => p.Price)
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Purchase>()
                  .HasOne(e => e.Customer)
                  .WithMany(e => e.Purchases)
                  .HasForeignKey(e => e.CustomerID);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            optionsBuilder.UseSqlServer(@"Server=(local);Database=Nutshell;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
