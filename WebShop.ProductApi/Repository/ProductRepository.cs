using Microsoft.EntityFrameworkCore;
using WebShop.ProductApi.Context;
using WebShop.ProductApi.Models;

namespace WebShop.ProductApi.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAll() =>
        await _context.Products.ToListAsync();

    public async Task<Product> GetById(int id) =>
        await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<Product> Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Delete(int id)
    {
        var product = await GetById(id);
        _context.Products.Remove(product);
        _context.SaveChangesAsync();
        return product;
    }
}
