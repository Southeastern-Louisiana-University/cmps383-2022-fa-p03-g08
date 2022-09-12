using FA22.P03.Web.Data;
using FA22.P03.Web.Features.Products;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FA22.P03.Web.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly DataContext<Product> products;
    private readonly DataContext dataContext;

    public ProductsController(DataContext dataContext)
    {
        this.dataContext = dataContext;
        products = dataContext.Set<Product>();
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return GetProductDtos(products);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<ProductDto> GetProductById(int id)
    {
        var result = GetProductDtos(products.Where(x => x.Id == id)).FirstOrDefault();
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<ProductDto> CreateProduct(ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
        };

        dataContext.Add(product);
        dataContext.SaveChanges();
        productDto.Id = product.Id;

        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, productDto);
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
        var now = DateTimeOffset.UtcNow;
        return products
            .Select(x => new
            {
                Product = x,
            })
            .Select(x => new ProductDto
            {
                Id = x.Product.Id,
                Name = x.Product.Name,
                Description = x.Product.Description,
            });
    }
}
