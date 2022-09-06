using FA22.P03.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace FA22.P03.Web.Dtos;

public class ProductDto
{
    public int Id { get; set; }

    [Required, MaxLength(120)]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set; } 

    [Required]
    public ICollection<Item> items { get; set; }

}