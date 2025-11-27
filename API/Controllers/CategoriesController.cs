using LogProject.Data;
using LogProject.Models.Domain;
using LogProject.Models.DTO;
using LogProject.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace LogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]CreateCategoryRequestDto request)
        {
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            await  _categoryRepository.CreateAsync(category);
         
            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);
        }

        [HttpGet]
         public async Task<IActionResult> GetAllCategories()
         {
            var categories =  await _categoryRepository.GetAllCategoriesAsync();
            var response = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                response.Add(new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                });
            }
            return Ok(response);
         }


         [HttpGet]
         [Route("{id:Guid}")]
         public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
         {
           var existingCategory = await _categoryRepository.GetCategoryById(id);
           if(existingCategory is null){
            return NotFound();
           }
           var response = new CategoryDTO
           {
            Id = existingCategory.Id,
            Name = existingCategory.Name,
            UrlHandle = existingCategory.UrlHandle
           };
              return Ok(response);
         }
    }
}
