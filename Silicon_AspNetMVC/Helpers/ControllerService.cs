using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Silicon_AspNetMVC.ViewModels.Account;

namespace Silicon_AspNetMVC.Helpers;

public class ControllerService(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, UserService userService, AddressService addressService)
{
    private readonly UserService _userService = userService;
    private readonly AddressService _addressService = addressService;
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;


     public async Task<AccountDetailsAddressInfoViewModel> PopulateAddressInfoAsync(UserEntity user)
        {
            try
            {
                var viewModel = new AccountDetailsAddressInfoViewModel();

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

    //private async Task<ProfileViewModel> PopulateProfileInfoAsync(UserEntity user)
    //{
    //    try
    //    {
    //        var user = await _userManager.GetUserAsync(User);
    //        return new ProfileViewModel
    //        {
    //            FirstName = user!.FirstName,
    //            LastName = user.LastName,
    //            Email = user.Email!,
    //        };
    //    }
    //    catch (Exception) { return new ProfileViewModel(); }
    //}

    //private async Task<AccountDetailsBasicInfoViewModel> PopulateBasicInfoAsync()
    //{
    //    try
    //    {
    //        var user = await _userManager.GetUserAsync(User);

    //        return new AccountDetailsBasicInfoViewModel
    //        {
    //            FirstName = user!.FirstName,
    //            LastName = user.LastName,
    //            Email = user.Email!,
    //            Phone = user.PhoneNumber,
    //            Bio = user.Biography,
    //            IsExternalAccount = user.IsExternalAccount,
    //        };
    //    }
    //    catch (Exception) { return new AccountDetailsBasicInfoViewModel(); }
    //}

    //private async Task<AccountDetailsAddressInfoViewModel> PopulateAddressInfoAsync()
    //{
    //    try
    //    {
    //        var viewModel = new AccountDetailsAddressInfoViewModel();
    //        var user = await _signInManager.UserManager.GetUserAsync(User);

    //        if (user is not null)
    //        {
    //            viewModel.Id = user.Id;
    //            var result = await _addressService.GetAddressByIdAsync(user.Id);

    //            if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
    //            {
    //                var addressModel = (AddressModel)result.ContentResult!;
    //                viewModel = new AccountDetailsAddressInfoViewModel(addressModel);
    //            }
    //        }
    //        return viewModel;
    //    }
    //    catch (Exception) { return new AccountDetailsAddressInfoViewModel(); }
    //}

    //private async Task<UserEntity> GenerateUserEntityAsync(AccountDetailsBasicInfoViewModel viewModel)
    //{
    //    try
    //    {
    //        var user = await _signInManager.UserManager.GetUserAsync(User);

    //        return UserFactory.Create(
    //                    viewModel.FirstName,
    //                    viewModel.LastName,
    //                    viewModel.Email,
    //                    viewModel.Phone!,
    //                    viewModel.Bio!,
    //                    user!.Id,
    //                    user.PasswordHash!,
    //                    user.NormalizedEmail!,
    //                    user.NormalizedUserName!,
    //                    user.UserName!
    //            );
    //    }
    //    catch (Exception) { return null!; }
    //}

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
