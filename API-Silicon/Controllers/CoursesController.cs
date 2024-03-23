using API_Silicon.Filters;
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
    [UseApiKey]
    public class CoursesController(DataContext context, CoursesRepository courseRepository) : ControllerBase
    {
        private readonly DataContext _context = context;
        private readonly CoursesRepository _courseRepository = courseRepository;

        #region CREATE
        [HttpPost]
        
        public async Task<IActionResult> Create(CourseRegistrationForm DTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CoursesEntity coursesEntity = DTO;
                    _context.Courses.Add(coursesEntity);
                    await _context.SaveChangesAsync();

                    return Created("", (CoursesModel)coursesEntity);
                }
                return BadRequest();
            }
            catch (Exception) { return BadRequest(); }
        }
        #endregion

        #region READ
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var response = await _courseRepository.GetOneAsync(x => x.Id == id);
                if (response.StatusCode == Infrastructure.Models.StatusCode.OK)
                {
                    return Ok(response.ContentResult);
                }
                return NotFound();
            }
            catch (Exception) { return BadRequest(); }
        }

        [HttpGet]
        [UseApiKey]
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
