﻿namespace WebShop.ProductApi.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public long Inventory { get; set; }
    public string? ImageURL { get; set; }
    public Category? Category { get; set; }
    public int CategoryID { get; set; }
}
