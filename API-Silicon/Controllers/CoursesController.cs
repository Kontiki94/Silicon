using API_Silicon.Filters;
using Infrastructure.Context;
using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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
        public async Task<IActionResult> GetAll(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var query = _context.Courses.Include(i => i.Category).AsQueryable();

                if (!string.IsNullOrEmpty(category) && category != "all")
                    query = query.Where(x => x.Category!.CategoryName == category);

                if (!string.IsNullOrEmpty(searchQuery))
                    query = query.Where(x => x.Title.Contains(searchQuery) || x.AuthorName!.Contains(searchQuery) || x.Category!.CategoryName.Contains(searchQuery));

                query = query.OrderByDescending(o => o.Updated);
                var courses = await query.ToListAsync();
                if (courses is not null)
                {
                    var response = new CourseResult
                    {
                        Succeeded = true,
                        TotalItems = await query.CountAsync(),
                    };
                    response.TotalPages = (int)Math.Ceiling(response.TotalItems / (double)pageSize);
                    response.Courses = CourseFactory.Create(await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync());

                    return Ok(response);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
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
