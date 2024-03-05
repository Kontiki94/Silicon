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
            var viewModel = new ContactViewModel();
            ViewData["Title"] = "Contact Us";
            return View(viewModel);
        }

        [Route("/contact")]
        [HttpPost]
        public IActionResult ContactUs(ContactViewModel viewModel)
        {
            if (!ModelState.IsValid)                //om formuläret inte är rätt ifyllt, retunera vy med felmeddelande
            {
                ViewData["Title"] = "Contact Us";
                return View(viewModel);
            }
            
            return RedirectToAction("ContactUs", "Contact");     //Om rätt ifyllt, tillbaks till vyn (eller RedirectToAction("Vy", "controller") om vi vill gå någon annanstans)
        }
    }
}
