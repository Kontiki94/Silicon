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
        try
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
        catch (Exception)
        {
            TempData["ErrorMessage"] = "An error occurred, please try again.";
            return RedirectToAction("Home", "Index");
        }

    }
    #endregion

    #region Account BasicInfo | Post
    [HttpPost]
    public async Task<IActionResult> AccountBasicInfo([Bind(Prefix = "Details")] AccountDetailsBasicInfoViewModel viewModel)
    {

        try
        {
            var externalUser = await _signInManager.GetExternalLoginInfoAsync();
            var claims = HttpContext.User.Identities.FirstOrDefault();
            var email = claims?.Name;

            if (externalUser is not null)
            {
                if (email is not null)
                {
                    var result = await CheckAndUpdateExternalUserAsync(viewModel, email!);

                    if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                    {
                        TempData["SuccessMessage"] = "Account information successfully saved";
                        return RedirectToAction(nameof(Details));
                    }
                }
            }
            else if (ModelState.IsValid)
            {
                var userEntity = await GenerateUserEntityAsync(viewModel);
                var result = await _userService.UpdateUserAsync(userEntity);

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
        catch (Exception)
        {
            TempData["ErrorMessage"] = "An error occurred, please try again.";
            return View("Details");
        }
    }
    #endregion

    #region Account AddressInfo | Post
    [HttpPost]
    public async Task<IActionResult> AccountAddressInfo([Bind(Prefix = "AddressInfo")] AccountDetailsAddressInfoViewModel viewModel)
    {
        try
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
        catch (Exception)
        {
            TempData["ErrorMessage"] = "An error occurred, please try again.";
            return View("Details");
        }
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
        try
        {
            var user = await _userManager.GetUserAsync(User);
            return new ProfileViewModel
            {
                FirstName = user!.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
            };
        }
        catch (Exception) { return new ProfileViewModel(); }
    }

    private async Task<AccountDetailsBasicInfoViewModel> PopulateBasicInfoAsync()
    {
        try
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
        catch (Exception) { return new AccountDetailsBasicInfoViewModel(); }
    }

    private async Task<AccountDetailsAddressInfoViewModel> PopulateAddressInfoAsync()
    {
        try
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
            }
            return viewModel;
        }
        catch (Exception) { return new AccountDetailsAddressInfoViewModel(); }
    }

    private async Task<UserEntity> GenerateUserEntityAsync(AccountDetailsBasicInfoViewModel viewModel)
    {
        try
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
        catch (Exception) { return null!; }
    }

    private async Task<AddressModel> GenerateAddressModelAsync(AccountDetailsAddressInfoViewModel viewModel)
    {
        try
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
        catch (Exception) { return null!; }
    }

    public async Task<ResponseResult> CheckAndUpdateExternalUserAsync(AccountDetailsBasicInfoViewModel viewModel, string email)
    {
        try
        {
            var externalUser = await _signInManager.GetExternalLoginInfoAsync();
            bool isFacebookUser = externalUser?.LoginProvider == "Facebook";
            bool isGoogleUser = externalUser?.LoginProvider == "Google";

            if (isFacebookUser || isGoogleUser)
            {
                var existingUser = await _userManager.FindByEmailAsync(email);

                if (existingUser is not null)
                {
                    existingUser.Biography = viewModel.Bio;
                    existingUser.PhoneNumber = viewModel.Phone;

                    var result = await _userService.UpdateUserAsync(existingUser);
                    return result;
                }
            }
            return ResponseFactory.NotFound();
        }
        catch (Exception) { return ResponseFactory.Error(); }
    }
}




