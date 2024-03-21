using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon_AspNetMVC.Models.Sections;
using Silicon_AspNetMVC.ViewModels.Courses;
using System.Text;

namespace Silicon_AspNetMVC.Controllers;

public class CoursesController : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Courses";

        var viewModel = new CoursesViewModel();

        try
        {
            using var http = new HttpClient();
            var response = await http.GetAsync("https://localhost:7091/api/courses?key=NmUyM2YyZTktOGUxYy00YTc2LTk4YzktMjEzOWYzMjI1ZTEz");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<CoursesModel>>(json);
                viewModel.AllCourses = data!;
            }
            else
            {
                TempData["ErrorMessage"] = "Unable to contact the server, please try again later";
                viewModel.AllCourses = new List<CoursesModel>();
            }
        }
        catch (HttpRequestException ex)
        {
            TempData["ErrorMessage"] = "API not responding, contact web admin";
            viewModel.AllCourses = new List<CoursesModel>();
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "API not responding, contact web admin";
            viewModel.AllCourses = new List<CoursesModel>();
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
            var response = await http.PostAsync("https://localhost:7091/api/courses", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Courses");
            }
        }
        return View(model);
    }



    [Route("/coursedetails")]
    public IActionResult CourseDetails()
    {
        ViewData["Title"] = "Course Details";
        var viewModel = new CoursesCourseDetailsViewModel();
        return View(viewModel);
    }
}
