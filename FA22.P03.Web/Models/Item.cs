namespace FA22.P03.Web.Features.Item
{
    public class Item
    {
        public int Id { get; set; }
        public Products Products { get; set; }
        public string Conditon { get; set; }
        public ICollection<ItemListing> itemListings { get; set; }
    }
}
