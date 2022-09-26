using System.ComponentModel.DataAnnotations;
using WebShop.ProductApi.Models;

namespace WebShop.ProductApi.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [MinLength(3)]
    [MaxLength(255)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Inventory is required")]
    [Range(0, 9999)]
    public long Inventory { get; set; }

    [Required(ErrorMessage = "Image URL is required")]
    [MinLength(3)]
    [MaxLength(255)]
    public string? ImageURL { get; set; }
    public Category? Category { get; set; }
    public int CategoryID { get; set; }
}
