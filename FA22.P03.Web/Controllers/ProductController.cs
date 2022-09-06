using FA22.P03.Web.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FA22.P03.Web.Controllers;

    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase

    
    public class ProductController : ControllerBase
    {

        private readonly DataContext _dataContext;

        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public ProductDto[] GetAllProducts()
        {
            var products = dataContext.Set<Product>();
            return GetProductDtos(products).ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProductDto> GetProductById(int id)
        {
            var products = dataContext.Set<Product>();
            var result = GetProductDtos(products).FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

       

        [HttpPut("{id}")]
        public ActionResult<ProductDto> UpdateProduct(int id, ProductDto productDto)
        {
            var products = dataContext.Set<Product>();
            var current = products.FirstOrDefault(x => x.Id == id);
            if (current == null)
            {
                return NotFound();
            }

            current.Name = productDto.Name;
            current.Description = productDto.Description;
            dataContext.SaveChanges();

            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductDto> DeleteProduct(int id)
        {
            var products = dataContext.Set<Product>();
            var current = products.FirstOrDefault(x => x.Id == id);
            if (current == null)
            {
                return NotFound();
            }

            products.Remove(current);
            dataContext.SaveChanges();

            return Ok();
        }

        private static IQueryable<ProductDto> GetProductDtos(IQueryable<Product> products)
        {
            return products
                .Select(x => new
                {
                    Product = x
                })
                .Select(x => new ProductDto
                {
                    Id = x.Product.Id,
                    Name = x.Product.Name,
                    Description = x.Product.Description,
  
                });
        }
    }

