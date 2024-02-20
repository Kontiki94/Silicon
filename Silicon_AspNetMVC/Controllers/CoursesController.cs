using Silicon_AspNetMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Silicon_AspNetMVC.Controllers;

public class CoursesController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new CoursesViewModel();
        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }
    
    public IActionResult Courses()
    {
        return View();
    }

    [Route("/coursedetails")]
    public IActionResult CourseDetails()
    {
        var viewModel = new CoursesCourseDetailsViewModel();
        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }
}
