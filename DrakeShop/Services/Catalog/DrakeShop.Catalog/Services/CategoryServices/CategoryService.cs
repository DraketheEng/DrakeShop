using DrakeShop.Catalog.Entities;
using DrakeShop.Catalog.MongoDB.Repository;

namespace DrakeShop.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMongoDbServices<Category> _categoryServices;

    public CategoryService(IMongoDbServices<Category> categoryServices)
    {
        _categoryServices = categoryServices;
    }

    public List<Category> GetAll()
    {
        var list = _categoryServices.FilterBy(x => true).ToList();
        return list;
    }

    public async Task<Category> GetById(string id)
    {
        var category = await _categoryServices.FindByIdAsync(id);
        return category;
    }

    public async Task<bool> Create(Category category)
    {
        await _categoryServices.InsertOneAsync(category);
        return true;
    }

    public async Task<bool> Delete(string id)
    {
        await _categoryServices.DeleteOneAsync(x => x.Id == id);
        return true;
    }

    public async Task<bool>  Update(Category category)
    {
        await _categoryServices.ReplaceOneAsync(category);
        return true;
    }
}