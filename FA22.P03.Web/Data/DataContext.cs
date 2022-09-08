﻿using FA22.P03.Web.Features.Items;
using FA22.P03.Web.Features.ItemListings;
using FA22.P03.Web.Features.Listings;
using Microsoft.EntityFrameworkCore;
using FA22.P03.Web.Features.Products;

namespace FA22.P03.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemListing> ItemListings { get; set; }
        public DbSet<Listing> Listings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(x => x.Id)
                .IsRequired();

            modelBuilder.Entity<Product>()
               .Property(x => x.Name)
               .IsRequired();

            modelBuilder.Entity<Product>()
               .Property(x => x.Description)
               .IsRequired();

            modelBuilder.Entity<Product>()
               .Property(x => x.Name)
               .IsRequired();


            modelBuilder.Entity<Item>()
               .Property(x => x.Product)
               .IsRequired();

            modelBuilder.Entity<Item>()
              .Property(x => x.Conditon)
              .IsRequired();

            modelBuilder.Entity<Listing>()
             .Property(x => x.Id)
             .IsRequired();

            modelBuilder.Entity<Listing>()
            .Property(x => x.Name)
            .IsRequired();

            modelBuilder.Entity<Listing>()
            .Property(x => x.Price)
            .IsRequired();

            modelBuilder.Entity<Listing>()
            .Property(x => x.StartUtc)
            .IsRequired();

            modelBuilder.Entity<Listing>()
            .Property(x => x.EndUtc)
            .IsRequired();

            modelBuilder.Entity<ItemListing>()
                .HasOne(x => x.Item)
                .WithMany(x => x.ItemListings);
        }
    }
}
