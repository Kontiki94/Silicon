using Infrastructure.Models.Sections;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Silicon_AspNetMVC.ViewModels.Account;
using Silicon_AspNetMVC.ViewModels.CompositeViewModels;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Factories;

namespace Silicon_AspNetMVC.Controllers
{
    [Authorize]
    public class AccountController(UserService userService, SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, AddressService addressService) : Controller
    {
        private readonly UserService _userService = userService;
        private readonly SignInManager<UserEntity> _signInManager = signInManager;
        private readonly UserManager<UserEntity> _manager = userManager;
        private readonly AddressService _addressService = addressService;

        // Fixa en GET för att förpopulera användaruppgifter och bild. 

        [HttpGet]
        [Route("/details")]
        public async Task<IActionResult> Details()
        {
            ViewData["Title"] = "Details";
            if (!_signInManager.IsSignedIn(User))
                return RedirectToAction(nameof(Details));

            var viewModel = new AccountViewModel()
            {
                Navigation = new NavigationViewModel("Details"),
                AddressInfo = new AccountDetailsAddressInfoViewModel(),
                Details = new AccountDetailsBasicInfoViewModel(),
            };

            var user = await _signInManager.UserManager.GetUserAsync(User);
            if (user is not null)
            {
                viewModel.AddressInfo.Id = user.Id;
                var result = await _addressService.GetAddressByIdAsync(user.Id);
                if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                {
                    var addressModel = (AddressModel)result.ContentResult!;
                    viewModel.AddressInfo = new AccountDetailsAddressInfoViewModel(addressModel);
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AccountBasicInfo(AccountViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _signInManager.UserManager.GetUserAsync(User);

                if (user is not null)
                {
                    var userModel = UserFactory.Create(
                        viewModel.Details.FirstName,
                        viewModel.Details.LastName,
                        viewModel.Details.Email,
                        viewModel.Details.Phone!,
                        viewModel.Details.Bio!,
                        user.Id,
                        user.PasswordHash!,
                        user.NormalizedEmail!,
                        user.NormalizedUserName!,
                        user.UserName!
                        );

                    var result = await _userService.UpdateUserAsync(userModel);
                    if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                        return RedirectToAction(nameof(Details));
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AccountAddressInfo(AccountViewModel viewModel)
        {
            viewModel.Navigation = new NavigationViewModel("Details");

            var user = await _signInManager.UserManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                if (user is not null)
                {
                    var addressModel = AddressFactory.Create(
                        viewModel.AddressInfo.Id!,
                        viewModel.AddressInfo.AddressLine1,
                        viewModel.AddressInfo.AddressLine2,
                        viewModel.AddressInfo.PostalCode,
                        viewModel.AddressInfo.City,
                        user.Id
                        );

                    var result = await _addressService.CreateOrUpdateAddressAsync(addressModel);
                    return RedirectToAction(nameof(Details));
                }
            }

            return View("Details", viewModel);
        }


        [HttpGet]
        [Route("/security")]
        public IActionResult Security()
        {
            var viewModel = new AccountViewModel();
            viewModel.Navigation = new NavigationViewModel("Security");
            ViewData["Title"] = "Security";
            return View(viewModel);
        }

        [HttpPost]
        [Route("/security")]
        public IActionResult Security(AccountViewModel viewModel)
        {
            var userEmail = _manager.GetUserName(User)!;
            viewModel.Navigation = new NavigationViewModel("Security");

            if (viewModel.ChangePass is not null)

            {
                if (viewModel.ChangePass.ConfirmPassword != null && viewModel.ChangePass.Password != null && viewModel.ChangePass.NewPassword != null && viewModel.ChangePass.NewPassword == viewModel.ChangePass.ConfirmPassword)
                {
                    var result = _userService.UpdateCredentials(new AccountSecurityModel()
                    {
                        Password = viewModel.ChangePass.Password,
                        NewPassword = viewModel.ChangePass.NewPassword,
                        ConfirmPassword = viewModel.ChangePass.ConfirmPassword
                    }, userEmail);

                    if (result.Result.StatusCode == Infrastructure.Models.StatusCode.OK)
                    {
                        return RedirectToAction("Details", "Account");
                    }
                }
            }
            return View("Security", viewModel);
        }

        [HttpPost]
        public IActionResult Delete(AccountViewModel viewModel)
        {
            var userEmail = _manager.GetUserName(User)!;
            viewModel.Navigation = new NavigationViewModel("Security");
            if (viewModel.Delete is not null)
            {
                if (viewModel.Delete.DeleteAccount == true)
                {
                    var result = _userService.DeleteUser(userEmail);
                    if (result.Result.StatusCode == Infrastructure.Models.StatusCode.OK)
                    {
                        _signInManager.SignOutAsync();
                        return RedirectToAction("SignUp", "Auth");
                    }
                }
            }
            return View("Security", viewModel);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Details", "Account");
        }

        [Route("/saved")]
        public IActionResult SavedCourses()
        {
            var viewModel = new SavedCoursesViewModel();
            return View(viewModel);
        }
    }
}

