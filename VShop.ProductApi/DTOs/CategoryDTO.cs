using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}
