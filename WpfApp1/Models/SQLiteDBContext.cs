using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Models
{
    class SQLiteDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public SQLiteDBContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=finances.db"); //файл базы данных
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*развертывание таблицы*/

            /*заполнение стартовыми данными*/
            //Category[] categories = new Category[]
            //{
            //    new Category {Id = 1, Name="Питание"},
            //    new Category {Id = 2, Name="Проезд"},
            //    new Category {Id = 3, Name="Личные траты"},
            //};

            //modelBuilder.Entity<Category>().HasData(categories);

            //modelBuilder.Entity<Product>().HasData(
            //    new Product[]
            //    {
            //        new Product {Id = 1, Name="Бензин", Price= 32, CategoryId = categories[1].Id},
            //        new Product {Id = 2, Name="Газ", Price= 16, CategoryId = categories[1].Id}
            //    }
            //); ;

            //modelBuilder.Entity<Category>(e =>
            //{
            //    e.HasKey(m => m.Id).HasName("PK_Category");

            //    e.Property(m => m.Id).ValueGeneratedOnAdd();

            //    e.Property(m => m.Name).IsRequired().HasMaxLength(64);
            //});

            //modelBuilder.Entity<Product>(e =>
            //{
            //    e.HasKey(m => m.Id).HasName("PK_Product");

            //    e.Property(m => m.Id).ValueGeneratedOnAdd();

            //    e.Property(m => m.Name).IsRequired().HasMaxLength(64);

            //    e.Property(m => m.Price).HasDefaultValue(0);

            //    modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId);

            //    //modelBuilder.Entity<Product>().HasForeignKey(p => p.AuthorFK);
            //});


        }
    }
}
