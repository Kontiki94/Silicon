using Silicon_AspNetMVC.Models.Sections;
using Silicon_AspNetMVC.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace Silicon_AspNetMVC.Controllers;

public class CoursesController : Controller
{
    public IActionResult CoursesIndex()
    {
        var viewModel = new CourseIndexViewModel
        {
            Title = "courses",
            Course = new CoursesViewModel
            {
                Id = "Courses",
                CourseTitle = "Fullstack Web Developer Course from Scratch",
                CourseImage = new() { ImageUrl = "images/fullstack_dev.png", AltText = "Macbook image" },
                Author = "Robert Fox",
                Price = 23,
                Views = 5000,
                Link = new() { ControllerName = "Course", ActionName = "Index" },
                Categories =
                [
                    "IT",
                    "Tech",
                    "DevOps",
                    "Data Analyst"
                    ],
            }
        };

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }
}
