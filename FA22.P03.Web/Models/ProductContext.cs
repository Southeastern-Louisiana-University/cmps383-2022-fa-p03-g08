using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FA22.P03.Web.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = null!;
    }
}
