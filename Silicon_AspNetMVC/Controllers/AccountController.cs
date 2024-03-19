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

namespace Silicon_AspNetMVC.Controllers;
[Authorize]
public class AccountController(UserService userService, SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, AddressService addressService) : Controller
{
    private readonly UserService _userService = userService;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly AddressService _addressService = addressService;

    #region Account | GET
    [HttpGet]
    [Route("/details")]
    public async Task<IActionResult> Details()
    {
        var viewModel = new AccountViewModel()
        {
            Navigation = new NavigationViewModel("Details"),
            AddressInfo = new AccountDetailsAddressInfoViewModel(),
            Details = new AccountDetailsBasicInfoViewModel(),
            SuccessMessage = TempData["SuccessMessage"]?.ToString() ?? "",
            ErrorMessage = TempData["ErrorMessage"]?.ToString() ?? "",
        };

        viewModel.AddressInfo = await PopulateAddressInfoAsync();
        viewModel.Details = await PopulateBasicInfoAsync();
        viewModel.Profile = await PopulateProfileInfoAsync();

        return View(viewModel);
    }
    #endregion

    #region Account BasicInfo | Post
    [HttpPost]
    public async Task<IActionResult> AccountBasicInfo([Bind(Prefix = "Details")] AccountDetailsBasicInfoViewModel viewModel)
    {
        var user = await PopulateBasicInfoAsync();
        if (user.IsExternalAccount)
        {
            ModelState.Remove("Details.FirstName");
            ModelState.Remove("Details.Lastname");
            ModelState.Remove("Details.Email");
        }
        if (ModelState.IsValid)
        {
            var userEnt = await GenerateUserEntityAsync(user);

            var result = await _userService.UpdateUserAsync(userEnt);
            if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
            {
                TempData["SuccessMessage"] = "Account information saved successfully";
                return RedirectToAction(nameof(Details));
            }
        }

        TempData["ErrorMessage"] = "Please fill in all required fields.";

        var compositeViewModel = new AccountViewModel
        {
            AddressInfo = new AccountDetailsAddressInfoViewModel(),
            Details = viewModel,
            Profile = new ProfileViewModel(),
            ErrorMessage = TempData["ErrorMessage"]?.ToString()!
        };

        compositeViewModel.AddressInfo = await PopulateAddressInfoAsync();
        compositeViewModel.Profile = await PopulateProfileInfoAsync();

        return View("Details", compositeViewModel);
    }
    #endregion

    #region Account AddressInfo | Post
    [HttpPost]
    public async Task<IActionResult> AccountAddressInfo([Bind(Prefix = "AddressInfo")] AccountDetailsAddressInfoViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var addressModel = await GenerateAddressModelAsync(viewModel);

            var result = await _addressService.CreateOrUpdateAddressAsync(addressModel);
            if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                TempData["SuccessMessage"] = "Address information saved successfully.";
            return RedirectToAction(nameof(Details));
        }

        TempData["ErrorMessage"] = "Please fill in all required fields.";

        var compositeViewModel = new AccountViewModel
        {
            AddressInfo = viewModel,
            Details = new AccountDetailsBasicInfoViewModel(),
            Profile = new ProfileViewModel(),
            ErrorMessage = TempData["ErrorMessage"]?.ToString()!
        };

        compositeViewModel.Profile = await PopulateProfileInfoAsync();
        compositeViewModel.Details = await PopulateBasicInfoAsync();

        return View("Details", compositeViewModel);
    }
    #endregion 

    #region Account Security | GET
    [HttpGet]
    [Route("/security")]
    public async Task<IActionResult> Security()
    {
        var viewModel = new AccountViewModel();
        viewModel.Navigation = new NavigationViewModel("Security");
        viewModel.Profile = await PopulateProfileInfoAsync();
        viewModel.SuccessMessage = TempData["SuccessMessage"]?.ToString() ?? "";
        viewModel.ErrorMessage = TempData["ErrorMessage"]?.ToString() ?? "";
        ViewData["Title"] = "Security";

        return View(viewModel);
    }
    #endregion

    #region Account Security | Post
    [HttpPost]
    [Route("/security")]
    public async Task<IActionResult> Security(AccountViewModel viewModel)
    {
        var userEmail = _userManager.GetUserName(User)!;
        viewModel.Navigation = new NavigationViewModel("Security");
        viewModel.Profile = await PopulateProfileInfoAsync();

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
                    TempData["SuccessMessage"] = "Password was updated!";
                    return RedirectToAction(nameof(Security));
                }
            }
        }
        return View("Security", viewModel);
    }
    #endregion

    #region Account Delete | Post
    [HttpPost]
    public async Task<IActionResult> Delete(AccountViewModel viewModel)
    {
        var userEmail = _userManager.GetUserName(User)!;
        viewModel.Navigation = new NavigationViewModel("Security");
        viewModel.Profile = await PopulateProfileInfoAsync();
        if (viewModel.Delete is not null)
        {
            if (viewModel.Delete.DeleteAccount == true)
            {
                var result = _userService.DeleteUser(userEmail);
                if (result.Result.StatusCode == Infrastructure.Models.StatusCode.OK)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("SignUp", "Auth");
                }
            }
        }
        return View("Security", viewModel);
    }
    #endregion


    public IActionResult Cancel()
    {
        return RedirectToAction("Details", "Account");
    }

    [Route("/saved")]
    public async Task<IActionResult> SavedCourses()
    {
        var viewModel = new AccountViewModel()
        {
            Navigation = new NavigationViewModel("SavedCourses"),
            Profile = await PopulateProfileInfoAsync()
        };
        return View(viewModel);
    }

    private async Task<ProfileViewModel> PopulateProfileInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new ProfileViewModel
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!,

        };
    }

    private async Task<AccountDetailsBasicInfoViewModel> PopulateBasicInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);

        return new AccountDetailsBasicInfoViewModel
        {
            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            Phone = user.PhoneNumber,
            Bio = user.Biography,
            IsExternalAccount = user.IsExternalAccount,
        };
    }

    private async Task<AccountDetailsAddressInfoViewModel> PopulateAddressInfoAsync()
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

    private async Task<UserEntity> GenerateUserEntityAsync(AccountDetailsBasicInfoViewModel viewModel)
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

    private async Task<AddressModel> GenerateAddressModelAsync(AccountDetailsAddressInfoViewModel viewModel)
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




