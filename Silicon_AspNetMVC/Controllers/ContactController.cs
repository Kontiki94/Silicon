using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon_AspNetMVC.Models.Sections;
using System.Text;

namespace Silicon_AspNetMVC.Controllers
{
    public class ContactController(IConfiguration configuration) : Controller
    {
        private readonly IConfiguration _configuration = configuration;

        [Route("/contact")]
        [HttpGet]    
        public IActionResult ContactUs()
        {
            var viewModel = new ContactModel();             
            ViewData["Title"] = "Contact Us";
            return View(viewModel);
        }

        [Route("/contact")]
        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactModel Model)
        {
            ViewData["Title"] = "Contact Us";
            if (ModelState.IsValid)                
            {
                using var http = new HttpClient();
                var json = JsonConvert.SerializeObject(Model);
                using var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await http.PostAsync($"https://localhost:7091/api/contact?key={_configuration["ApiKey:Secret"]}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Status"] = "Success";
                }

                return RedirectToAction("ContactUs", "Contact");
            }
            else
            {
                TempData["Status"] = "Error";

                return View(Model);
            }
        }
    }
}
