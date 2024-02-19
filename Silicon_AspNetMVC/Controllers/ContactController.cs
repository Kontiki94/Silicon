using Microsoft.AspNetCore.Mvc;

namespace Silicon_AspNetMVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
