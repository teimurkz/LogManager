using LogProject.Data;
using LogProject.Models.Domain;

namespace LogProject.Repositories.Implementation;

public class CategoryRepository:ICategoryRepository

{
    private readonly AppDbContext _dbContext;

    public CategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Category> CreateAsync(Category category)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync(); 
        return category;
    }
}