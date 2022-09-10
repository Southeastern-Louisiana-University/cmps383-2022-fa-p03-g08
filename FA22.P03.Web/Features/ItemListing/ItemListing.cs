using FA22.P03.Web.Features.Items;
using FA22.P03.Web.Features.Listings;
using Microsoft.EntityFrameworkCore;

namespace FA22.P03.Web.Features.ItemListings;

[Keyless]
public class ItemListing 
{
    public Item Item { get; set; }

    public Listing listing { get; set; }
}

