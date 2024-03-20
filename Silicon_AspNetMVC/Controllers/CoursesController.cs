using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon_AspNetMVC.Models.Sections;
using Silicon_AspNetMVC.ViewModels.Courses;

namespace Silicon_AspNetMVC.Controllers;

public class CoursesController : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Courses";

        var viewModel = new CoursesViewModel();

        using var http = new HttpClient();
        var response = await http.GetAsync("https://localhost:7091/api/courses");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<CoursesModel>>(json);
            viewModel.AllCourses = data!;
        }

        return View(viewModel);
    }



    [Route("/coursedetails")]
    public IActionResult CourseDetails()
    {
        ViewData["Title"] = "Course Details";
        var viewModel = new CoursesCourseDetailsViewModel();
        return View(viewModel);
    }
}
