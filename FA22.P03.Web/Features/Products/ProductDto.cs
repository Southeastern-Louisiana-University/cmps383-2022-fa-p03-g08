using System.ComponentModel.DataAnnotations;

namespace FA22.P03.Web.Features.Products;

public class ProductDto
{
    public int Id { get; set; }

    [Required, MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public ICollection<Item> items { get; set; }

}