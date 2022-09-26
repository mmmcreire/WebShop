using Microsoft.EntityFrameworkCore;
using WebShop.ProductApi.Context;
using WebShop.ProductApi.Models;

namespace WebShop.ProductApi.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAll() =>
        await _context.Categories.ToListAsync();

    async Task<Category> ICategoryRepository.GetById(int id) =>
        await _context.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();


    public async Task<IEnumerable<Category>> GetCategoriesProducts() =>
        await _context.Categories.Include(c => c.Products).ToListAsync();

    async Task<Category> ICategoryRepository.Create(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    async Task<Category> ICategoryRepository.Update(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return category;
    }

    async Task<Category> ICategoryRepository.Delete(int id)
    {
        var category = await _context.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
        _context.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }
}