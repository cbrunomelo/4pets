﻿using Domain.Entitys;
using Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infra
{
    public class StoreDbContext : DbContext
    {
        //public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //C:\Users\zois\source\repos\4pets

            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=4pets;Trusted_Connection=True;TrustServerCertificate=True;");

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<HistoryField> HistoryFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ClientMapping());
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new OrderItemMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new StockMapping());
            modelBuilder.ApplyConfiguration(new HistoryMapping());
            modelBuilder.ApplyConfiguration(new HistoryFieldMapping());


        }
    }
}
