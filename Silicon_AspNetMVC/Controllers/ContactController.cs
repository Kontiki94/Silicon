using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels.Contact;

namespace Silicon_AspNetMVC.Controllers
{
    public class ContactController : Controller
    {

        [Route("/contact")]
        [HttpGet]    
        public IActionResult ContactUs()
        {
            var viewModel = new ContactViewModel() 
            { 
                SuccessMessage = TempData["SuccessMessage"]?.ToString() ?? "",
                ErrorMessage = TempData["ErrorMessage"]?.ToString() ?? "",
            };
            ViewData["Title"] = "Contact Us";
            return View(viewModel);
        }

        [Route("/contact")]
        [HttpPost]
        public IActionResult ContactUs(ContactViewModel viewModel)
        {
            ViewData["Title"] = "Contact Us";
            if (ModelState.IsValid)                
            {
                TempData["SuccessMessage"] = "Contact was sent";
                return RedirectToAction("ContactUs", "Contact");     
                
            }
            else
            {
                TempData["ErrorMessage"] = "Please fill in all requierd fields.";
                viewModel = new ContactViewModel()
                {
                    SuccessMessage = TempData["SuccessMessage"]?.ToString() ?? "",
                    ErrorMessage = TempData["ErrorMessage"]?.ToString() ?? "",
                };
            }
            return View(viewModel);
           
        }
    }
}
