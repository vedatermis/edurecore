﻿using System.Reflection.Metadata.Ecma335;
using Edura.WebUI.Entity;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EduraContext: DbContext
    {
        public EduraContext(DbContextOptions<EduraContext> options): base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(pk => new
            {
                pk.ProductId,
                pk.CategoryId
            });
        }
    }
}