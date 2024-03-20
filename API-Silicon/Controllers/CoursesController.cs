using Infrastructure.Context;
using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace API_Silicon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(DataContext context, CoursesRepository courseRepository) : ControllerBase
    {
        private readonly DataContext _context = context;
        private readonly CoursesRepository _courseRepository = courseRepository;

        [HttpPost]
        public async Task<IActionResult> Create(CourseRegistrationForm DTO)
        {
            if (ModelState.IsValid)
            {
                var courseEntity = new CoursesEntity
                {
                    Title = DTO.Title,
                    Price = DTO.Price,
                    DiscountPrice = DTO.DiscountPrice,
                    CourseImage = DTO.CourseImage,
                    Rating = DTO.Rating,
                    Reviews = DTO.Reviews,
                    Views = DTO.Views,
                    Likes = DTO.Likes,
                    ViewHours = DTO.ViewHours,
                    AuthorName = DTO.AuthorName
                };
                _context.Courses.Add(courseEntity);
                await _context.SaveChangesAsync();

                return Created("", (CoursesModel)courseEntity);
            }
            return BadRequest();
        }

        #region READ
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {

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
