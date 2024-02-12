using Microsoft.AspNetCore.Mvc;

namespace Silicon_AspNetMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {

        ViewData["Title"] = "Silicon";

        return View();
    }
}
