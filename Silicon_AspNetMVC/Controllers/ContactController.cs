using Microsoft.AspNetCore.Mvc;

namespace Silicon_AspNetMVC.Controllers
{
    public class ContactController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
