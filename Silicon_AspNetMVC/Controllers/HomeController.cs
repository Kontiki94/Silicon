using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using Silicon_AspNetMVC.ViewModels.Home;
using System.Text;

namespace Silicon_AspNetMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel();
        ViewData["Title"] = "Silicon";
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Subscribe()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Subscribe(NewsLetterViewModel model)
    {
        if (ModelState.IsValid)
        {
            using var http = new HttpClient();
            var url = $"https://localhost:7091/api/Subscriber?email={model.Subscriber.Email}";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var response = await http.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                ViewData["Subscribed"] = true;
            }
        }
        return RedirectToAction("Index", "Home", "newsletter");
    }
}
