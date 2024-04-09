using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon_AspNetMVC.ViewModels.Courses;
using System.Net.Http.Headers;
using System.Text;

namespace Silicon_AspNetMVC.Controllers;

[Authorize]
public class CoursesController(HttpClient http, IConfiguration configuration, CategoryService categoryService, CourseService courseService, UserManager<UserEntity> userManager) : Controller
{
    private readonly HttpClient _http = http;
    private readonly IConfiguration _configuration = configuration;
    private readonly CategoryService _categoryService = categoryService;
    private readonly CourseService _courseService = courseService;
    private readonly UserManager<UserEntity> _userManager = userManager;


    public async Task<IActionResult> Index(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 3)
    {
        try
        {
            var courseResult = await _courseService.GetCoursesAsync(category, searchQuery, pageNumber, pageSize);

            //if (savedCourseId > 0)
            //{
            //    await _courseService.SaveCourseIdAsync(savedCourseId, User);
            //    return NoContent();
            //}

            var viewModel = new CoursesViewModel()
            {
                Categories = await _categoryService.GetCategoriesAsync(),
                AllCourses = courseResult.Courses,
                Pagination = new Pagination
                {
                    PageSize = pageSize,
                    CurrentPage = pageNumber,
                    TotalPages = courseResult.TotalPages,
                    TotalItems = courseResult.TotalItems
                }
            };

            if (viewModel.AllCourses == null)
            {
                ViewData["Status"] = "ConnectionFailed";
            }

            ViewData["Title"] = "Courses";
            return View(viewModel);
        }
        catch (Exception)
        {
            ViewData["Error"] = "An error occurred while trying to create a new course, please try again later";
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(int savedCourseId)
    {
        if (savedCourseId > 0)
        {
            await _courseService.SaveCourseIdAsync(savedCourseId, User);
            return Ok();
        }
        return BadRequest();
    }

   
    public async Task<IActionResult> Create(CoursesModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
                {
                    _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var json = JsonConvert.SerializeObject(model);
                    using var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _http.PostAsync($"https://localhost:7091/api/courses?key={_configuration["ApiKey:Secret"]}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Courses");
                    }
                }
            }
            catch (Exception)
            {
                ViewData["Error"] = "An error occurred while trying to create a new course, please try again later";
            }
        }
        return View(model);
    }


    [Route("/course/{id}")]
    public async Task<IActionResult> CourseDetails(int id)
    {
        ViewData["Title"] = "Course Details";
        try
        {
            var apiResponse = await _http.GetAsync($"https://localhost:7091/api/courses/{id}?key={_configuration["ApiKey:Secret"]}");
            if (apiResponse.IsSuccessStatusCode)
            {
                var json = await apiResponse.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CoursesModel>(json);
                CoursesModel viewModel = data!;
                return View(viewModel);
            }
        }
        catch (Exception)
        {
            ViewData["Error"] = "An error occurred while trying to create a new course, please try again later";
        }
        return View();
    }
}
