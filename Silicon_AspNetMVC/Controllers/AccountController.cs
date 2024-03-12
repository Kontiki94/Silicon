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
using Microsoft.Identity.Client;

namespace Silicon_AspNetMVC.Controllers;

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

            viewModel.Details.FirstName = user.FirstName;
            viewModel.Details.LastName = user.LastName;
            viewModel.Details.Email = user.Email!;
            viewModel.Details.Phone = user.PhoneNumber;
            viewModel.Details.Bio = user.Biography;
        }

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> AccountBasicInfo([Bind(Prefix = "Details")] AccountDetailsBasicInfoViewModel viewModel)
    {
        var user = await _signInManager.UserManager.GetUserAsync(User);

        if (user is not null)
        {
            if (ModelState.IsValid)
            {
                var userEntity = await GenerateUserEntity(viewModel);

                var result = await _userService.UpdateUserAsync(userEntity);
                if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                    return RedirectToAction(nameof(Details));
            }
            else
            {
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        Console.WriteLine($"ModelState Error: {error.ErrorMessage}");
                    }
                }
                ModelState.AddModelError("", "Please fill in all required fields.");
            }
        }
        var compositeViewModel = new AccountViewModel
        {
            Details = viewModel,
            AddressInfo = new AccountDetailsAddressInfoViewModel(),
        };


        compositeViewModel.AddressInfo = await PopulateAddressInfo();

        return View("Details", compositeViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> AccountAddressInfo([Bind(Prefix = "AddressInfo")]AccountDetailsAddressInfoViewModel viewModel)
    {
        var user = await _signInManager.UserManager.GetUserAsync(User);

        if (user is not null)
        {
            if (ModelState.IsValid)
            {
                var addressModel = await GenerateAddressModel(viewModel);

                var result = await _addressService.CreateOrUpdateAddressAsync(addressModel);
                if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                    return RedirectToAction(nameof(Details));
            }
            else
            {
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        Console.WriteLine($"ModelState Error: {error.ErrorMessage}");
                    }
                }
                ModelState.AddModelError("", "Please fill in all required fields.");
            }
        }
        var compositeViewModel = new AccountViewModel
        {
            Details = new AccountDetailsBasicInfoViewModel(),
            AddressInfo = viewModel
        };
        compositeViewModel.Details = await PopulateBasicInfo();
        return View("Details", compositeViewModel);
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

    private async Task<AccountDetailsBasicInfoViewModel> PopulateBasicInfo()
    {
        var user = await _manager.GetUserAsync(User);

        return new AccountDetailsBasicInfoViewModel
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            Phone = user.PhoneNumber,
            Bio = user.Biography
        };
    }

    private async Task<AccountDetailsAddressInfoViewModel> PopulateAddressInfo()
    {
        var viewModel = new AccountDetailsAddressInfoViewModel();
        var user = await _signInManager.UserManager.GetUserAsync(User);

        if (user is not null)
        {
            viewModel.Id = user.Id;
            var result = await _addressService.GetAddressByIdAsync(user.Id);

            if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
            {
                var addressModel = (AddressModel)result.ContentResult!;
                viewModel = new AccountDetailsAddressInfoViewModel(addressModel);
            }
            return viewModel;
        }
        return null!;
    }

    private async Task<UserEntity> GenerateUserEntity(AccountDetailsBasicInfoViewModel viewModel)
    {
        var user = await _signInManager.UserManager.GetUserAsync(User);

        return UserFactory.Create(
            viewModel.FirstName,
                    viewModel.LastName,
                    viewModel.Email,
                    viewModel.Phone!,
                    viewModel.Bio!,
                    user!.Id,
                    user.PasswordHash!,
                    user.NormalizedEmail!,
                    user.NormalizedUserName!,
                    user.UserName!
            );
    }

    private async Task<AddressModel> GenerateAddressModel(AccountDetailsAddressInfoViewModel viewModel)
    {
        var user = await _signInManager.UserManager.GetUserAsync(User);

        return AddressFactory.Create(
                    viewModel.Id!,
                    viewModel.AddressLine1,
                    viewModel.AddressLine2,
                    viewModel.PostalCode,
                    viewModel.City,
                    user!.Id
                    );
    }
}


