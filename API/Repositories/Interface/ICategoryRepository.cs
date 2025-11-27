using LogProject.Models.Domain;

namespace LogProject.Repositories.Implementation;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryById(Guid id);
    
}
