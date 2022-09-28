﻿using Microsoft.AspNetCore.Mvc;
using WebShop.ProductApi.DTOs;
using WebShop.ProductApi.Services;

namespace WebShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var productDTO = await _productService.GetProducts();
        if(productDTO is null)
            return NotFound("Products not found");

        return Ok(productDTO);
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get(int id)
    {
        var productDTO = await _productService.GetProductById(id);
        if(productDTO is null)
            return NotFound("Product not found");

        return Ok(productDTO);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
    {
        if(productDTO is null)
            return BadRequest("Invalid Data");

        await _productService.AddProduct(productDTO);
        return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
    {
        if(id != productDTO.Id)
            return BadRequest();

        if(productDTO is null)
            return BadRequest();

        await _productService.UpdateProduct(productDTO);
        return Ok(productDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ProductDTO>> Delete(int id)
    {
        var productDTO = await _productService.GetProductById(id);

        if(id != productDTO.Id)
            return BadRequest();

        if(productDTO is null)
            return BadRequest();

        await _productService.DeleteProduct(id);
        return Ok(productDTO);
    }
}
