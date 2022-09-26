using WebShop.ProductApi.Models;

namespace WebShop.ProductApi.Repository;

public interface ICategoryRepository
{
    public Task<IEnumerable<Category>> GetAll();
    public Task<IEnumerable<Category>> GetCategoriesProducts();
    public Task<Category> GetById(int id);
    public Task<Category> Create(Category category);
    public Task<Category> Update(Category category);
    public Task<Category> Delete(int id);
}
