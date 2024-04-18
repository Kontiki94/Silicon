using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Silicon_AspNetMVC.ViewModels.Account;

namespace Silicon_AspNetMVC.Services;

public class ControllerService(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, UserService userService)
{
    private readonly UserService _userService = userService;
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

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
