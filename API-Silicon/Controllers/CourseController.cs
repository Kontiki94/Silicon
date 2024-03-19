using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace API_Silicon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(DataContext context, CourseRepository courseRepository) : ControllerBase
    {
        private readonly DataContext _context = context;
        private readonly CourseRepository _courseRepository = courseRepository;

        [HttpPost]
        public async Task<IActionResult> Create(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {

            }
            return BadRequest();
        }

        #region READ
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Invalid id");
            }

            var response = await _courseRepository.GetOneAsync(x => x.Id == id);
            if (response.StatusCode == Infrastructure.Models.StatusCode.OK)
            {
                return Ok(response.ContentResult);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var courses = await _courseRepository.GetAllAsync();
                if (courses is not null)
                {
                    return Ok(courses);
                }
                return NotFound();

            }
            catch (Exception) { return BadRequest(); }
        }


        #endregion

        #region UPDATE
        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }
        #endregion

        #region DELETE
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();

        }
        #endregion

    }
}
