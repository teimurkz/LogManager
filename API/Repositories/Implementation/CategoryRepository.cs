using LogProject.Data;
using LogProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

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

    public async  Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }

     public async Task<Category?> GetCategoryById(Guid id){
        return await _dbContext.Categories.FirstOrDefaultAsync(x=>x.Id == id);
    }
}