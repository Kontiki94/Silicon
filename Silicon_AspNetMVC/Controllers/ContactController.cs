using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.Controllers
{
    public class ContactController : Controller
    {

        [Route("/contact")]
        [HttpGet]    
        public IActionResult ContactUs()
        {
            var viewModel = new ContactViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ContactUs(ContactViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
