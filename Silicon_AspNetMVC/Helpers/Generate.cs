using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Silicon_AspNetMVC.ViewModels.Account;

namespace Silicon_AspNetMVC.Helpers
{
    public class Generate(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, AddressService addressService) : Controller
    {
        private readonly SignInManager<UserEntity> _signInManager = signInManager;
        private readonly UserManager<UserEntity> _manager = userManager;
        private readonly AddressService _addressService = addressService;

        public static ProfileViewModel PopulateProfileInfoAsync(UserEntity user)
        {

            return new ProfileViewModel
            {
                FirstName = user!.FirstName,
                LastName = user.LastName,
                Email = user.Email!,

            };
        }

        public static AccountDetailsBasicInfoViewModel PopulateBasicInfoAsync(UserEntity user)
        {

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

        public async Task<AccountDetailsAddressInfoViewModel> PopulateAddressInfoAsync(UserEntity user)
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
                return viewModel;
            }
            return null!;
        }


        public static UserEntity GenerateUserEntityAsync(AccountDetailsBasicInfoViewModel viewModel, UserEntity user)
        {

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

        public static AddressModel GenerateAddressModelAsync(AccountDetailsAddressInfoViewModel viewModel, UserEntity user)
        {
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
}
