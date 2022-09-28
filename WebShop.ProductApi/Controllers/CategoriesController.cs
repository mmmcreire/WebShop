using Microsoft.AspNetCore.Mvc;
using WebShop.ProductApi.DTOs;
using WebShop.ProductApi.Services;

namespace WebShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
    {
        var categoriesDTO = await _categoryService.GetCategories();
        if(categoriesDTO is null)
            return NotFound("Not found any category");

        return Ok(categoriesDTO);
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProduct()
    {
        var categoriesDTO = await _categoryService.GetCategoriesProducts();
        if(categoriesDTO is null)
            return NotFound("Not found any category");

        return Ok(categoriesDTO);
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get(int id)
    {
        var categoriesDTO = await _categoryService.GetCategoryById(id);
        if(categoriesDTO is null)
            return NotFound("Category not found");

        return Ok(categoriesDTO);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
    {
        if(categoryDTO is null)
            return BadRequest("Invalid Data");

        await _categoryService.AddCategory(categoryDTO);
        return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.CategoryId }, categoryDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
    {
        if(id != categoryDTO.CategoryId)
            return BadRequest();

        if(categoryDTO is null)
            return BadRequest();

        await _categoryService.UpdateCategory(categoryDTO);
        return Ok(categoryDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CategoryDTO>> Delete(int id)
    {
        var categoryDTO = await _categoryService.GetCategoryById(id);

        if(id != categoryDTO.CategoryId)
            return BadRequest();

        if(categoryDTO is null)
            return BadRequest();

        await _categoryService.DeleteCategory(id);
        return Ok(categoryDTO);
    }
}
