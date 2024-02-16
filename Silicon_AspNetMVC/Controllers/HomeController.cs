using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.Models.Views;

namespace Silicon_AspNetMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel();
        ViewData["Title"] = "Silicon";
        return View(viewModel);
    }
}
