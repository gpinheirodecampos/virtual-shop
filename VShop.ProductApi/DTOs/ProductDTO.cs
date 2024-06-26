﻿using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs;

public class ProductDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public long Stock { get; set; }
    public Category? Category { get; set; }
    public int? CategoryId { get; set; }
}
