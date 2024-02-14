using Microsoft.AspNetCore.Mvc;

namespace Silicon_AspNetMVC.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult CoursesIndex()
        {
            ViewData["Title"] = "Courses";
            return View();
        }
    }
}
