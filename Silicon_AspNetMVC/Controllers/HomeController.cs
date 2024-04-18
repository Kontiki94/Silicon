using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels.Home;
using System.Diagnostics;

namespace Silicon_AspNetMVC.Controllers;

public class HomeController(IConfiguration configuration) : Controller
{

    private readonly IConfiguration _configuration = configuration;

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
    public async Task<IActionResult> Subscribe(SubscribeModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                using var http = new HttpClient();
                var url = $"https://localhost:7091/api/Subscriber?email={model.Email}&key={_configuration["ApiKey:Secret"]}";
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                var response = await http.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                else
                {
                    return Conflict();
                }
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }
}
