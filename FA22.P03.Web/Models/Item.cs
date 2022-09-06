
namespace FA22.P03.Web.Models;

    public class Item
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string Conditon { get; set; }
        public ICollection<ItemListing> ItemListings { get; set; }
    }

