using FA22.P03.Web.Data;
using FA22.P03.Web.Features.Items;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FA22.P03.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ItemController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<ItemController>
        [HttpGet]
        /*public IActionResult Get()
        {
            

           
            _dataContext.SaveChanges();
        }
       */

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemController>
        [HttpPost]
        public void CreateItem(ItemDto itemDto)
        {
            var itemToCreate = new ItemDto { Id = itemDto.Id, Condition = itemDto.Condition, ProductId = itemDto.ProductId, ProductName = itemDto.ProductName };

            
            _dataContext.SaveChanges();
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
