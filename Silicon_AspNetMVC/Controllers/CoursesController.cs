using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon_AspNetMVC.Models.Sections;
using Silicon_AspNetMVC.ViewModels.Courses;
using System.Net.Http.Headers;
using System.Text;

namespace Silicon_AspNetMVC.Controllers;

[Authorize]
public class CoursesController(HttpClient http, IConfiguration configuration) : Controller
{
    private readonly HttpClient _http = http;
    private readonly IConfiguration _configuration = configuration;


    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Courses";
        var viewModel = new CoursesViewModel();

        try
        {
            if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var apiResponse = await _http.GetAsync($"https://localhost:7091/api/courses?key={_configuration["ApiKey:Secret"]}");
                if (apiResponse.IsSuccessStatusCode)
                {
                    var json = await apiResponse.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<IEnumerable<CoursesModel>>(json);
                    viewModel.AllCourses = data!;
                }
                else
                {
                    ViewData["Status"] = "ConnectionFailed";
                }
            }
        }
        catch
        {
            ViewData["Status"] = "ConnectionFailed";
        }
        return View(viewModel);
    }


    public async Task<IActionResult> Create(CoursesModel model)
    {
        if (ModelState.IsValid)
        {
            using var http = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await http.PostAsync("https://localhost:7091/api/courses?key=NmUyM2YyZTktOGUxYy00YTc2LTk4YzktMjEzOWYzMjI1ZTEz", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Courses");
            }
        }
        return View(model);
    }



    [Route("/course/{id}")]
    public async Task<IActionResult> CourseDetails(string id)
    {
        ViewData["Title"] = "Course Details";

        if (HttpContext.Request.Cookies.TryGetValue("AccessToken", out var token))
        {
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var apiResponse = await _http.GetAsync($"https://localhost:7091/api/courses/{id}?key={_configuration["ApiKey:Secret"]}");
            if (apiResponse.IsSuccessStatusCode)
            {
                var json = await apiResponse.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CoursesModel>(json);
                CoursesModel viewModel = data!;
                return View(viewModel);
            }
        }
        return View();
    }
}
