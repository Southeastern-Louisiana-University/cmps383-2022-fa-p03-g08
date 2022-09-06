using FA22.P03.Web.Features.Item;
using FA22.P03.Web.Features.ItemListing;
using FA22.P03.Web.Features.Listing;
using FA22.P03.Web.Features.Products;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
    }
    
}
