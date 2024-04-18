using Infrastructure.Context;
using Infrastructure.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Silicon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(DataContext dataContext) : ControllerBase
    {
        private readonly DataContext _dataContext = dataContext;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _dataContext.Categories.OrderBy(c => c.CategoryName).ToListAsync();
            return Ok(CategoryFactory.Create(categories));
        }
    }
}
