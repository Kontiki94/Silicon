using Silicon_AspNetMVC.Models.Sections;
using Silicon_AspNetMVC.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace Silicon_AspNetMVC.Controllers;

public class CoursesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Courses()
    {
        var viewModel = new CoursesViewModel();
        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }

    public IActionResult CourseDetails()
    {
        var viewModel = new CoursesCourseDetailsViewModel();
        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }
}
