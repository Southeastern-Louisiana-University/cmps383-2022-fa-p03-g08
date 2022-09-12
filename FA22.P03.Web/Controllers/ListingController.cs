using FA22.P03.Web.Data;
using Microsoft.AspNetCore.Mvc;
using FA22.P03.Web.Features.Listings;
using FA22.P03.Web.Features.Items;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FA22.P03.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly DbSet<Listing> listings;
        private readonly DataContext _dataContext;
        private readonly DbSet<Item> items;

        public ListingController(DataContext dataContext)
        {
            _dataContext = dataContext
            listings = dataContext.Set<Listing>();
            items = dataContext.Set<Item>();
        }
        // GET: api/<Listing>
        
        [HttpGet]
        [Route("active")]
        public IQueryable<ListingDto> GetActiveListings()
        {
            var now = DateTimeOffset.UtcNow;
            return GetListingDtos(listings.Where(x => x.StartUtc <= now && now <= x.EndUtc));
        }

        // GET api/<Listing>/5
        [HttpGet]
        [Route("{id}")]
        public ActionResult<ListingDto> GetListingById(int id)
        {
            var result = GetListingDtos(listings.Where(x => x.Id == id)).FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<Listing>
       [HttpPost]
        public ActionResult<ListingDto> CreateListing(ListingDto dto)
        {
            if (IsInvalid(dto))
            {
                return BadRequest();
            }

            var listing = new Listing
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price.Value,
                StartUtc = dto.StartUtc.Value,
                EndUtc = dto.EndUtc.Value
            };
            listings.Add(listing);

            dataContext.SaveChanges();

            dto.Id = listing.Id;

            return CreatedAtAction(nameof(GetListingById), new { id = dto.Id }, dto);
        }

        // PUT api/<Listing>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Listing>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
