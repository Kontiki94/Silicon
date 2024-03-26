using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon_AspNetMVC.Models.Sections;
using System.Text;

namespace Silicon_AspNetMVC.Controllers
{
    public class ContactController : Controller
    {

        [Route("/contact")]
        [HttpGet]    
        public IActionResult ContactUs()
        {
            var viewModel = new ContactModel() 
            { 
                //SuccessMessage = TempData["SuccessMessage"]?.ToString() ?? "",
                //ErrorMessage = TempData["ErrorMessage"]?.ToString() ?? "",
            };
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
                var response = await http.PostAsync("https://localhost:7091/api/contact", content);

                if (response.IsSuccessStatusCode)
                {
                    ViewData["Status"] = "Success";
                }              
                
            }
            else
            {
                ViewData["Status"] = "Error";              
            }            
                return View(Model);
           
        }
    }
}
