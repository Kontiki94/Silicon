using Microsoft.AspNetCore.Mvc;

namespace Silicon_AspNetMVC.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
