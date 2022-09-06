using FA22.P03.Web.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FA22.P03.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ListingController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<Listing>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Listing>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Listing>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
