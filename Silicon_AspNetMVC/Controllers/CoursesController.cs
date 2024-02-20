using Silicon_AspNetMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Silicon_AspNetMVC.Controllers;

public class CoursesController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new CoursesViewModel();
        ViewData["Title"] = "Courses";
        return View(viewModel);
    }

    //public IActionResult Courses()
    //{
    //    var viewModel = new CoursesViewModel();
    //    ViewData["Title"] = "Courses";
    //    return View(viewModel);
    //}

    [Route("/coursedetails")]
    public IActionResult CourseDetails()
    {
        var viewModel = new CoursesCourseDetailsViewModel();
        ViewData["Title"] = "Course Details";
        return View(viewModel);
    }
}
