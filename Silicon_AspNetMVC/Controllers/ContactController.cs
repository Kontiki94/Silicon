using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Contact Us";
            return View();
        }
    }
}
