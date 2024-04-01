using API_Silicon.Filters;
using Infrastructure.Context;
using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(CourseRegistrationForm DTO, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CoursesEntity entity = DTO;
                    entity.Id = id;

                    var updatedCourse = await _courseRepository.UpdateAsync(x => x.Id == id, entity);

                    if (updatedCourse.StatusCode == Infrastructure.Models.StatusCode.OK)
                    {
                        return Ok(updatedCourse);
                    }

                    return NotFound();
                }

                return BadRequest(ModelState);
            }
            catch (Exception) { return BadRequest(); }
        }
        #endregion

        #region DELETE
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var courseToDelete = await _courseRepository.DeleteOneAsync(x => x.Id == id);
                if (courseToDelete)
                {
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception) { return BadRequest(); }
        }
        #endregion
    }
}
