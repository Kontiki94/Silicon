using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels.Courses;

namespace Silicon_AspNetMVC.Controllers;

public class CoursesController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new CoursesViewModel();
        ViewData["Title"] = "Courses";
        return View(viewModel);
    }

    //Behövs inte, men får ligga kvar ett tag för säkerhets skull. 
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
