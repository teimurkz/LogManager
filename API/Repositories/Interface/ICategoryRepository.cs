using LogProject.Models.Domain;

namespace LogProject.Repositories.Implementation;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category);
}
