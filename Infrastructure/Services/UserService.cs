using Infrastructure.Entitys;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Services
{
    public class UserService(UserRepository repository, AddressService addressService)
    {
        private readonly UserRepository _repository = repository;
        private readonly AddressService _addressService = addressService;

        public async Task<ResponseResult> CreateUserAsync(SignUpModel model)
        {
            try
            {
                var exists = await _repository.AlreadyExistsAsync(x => x.Email == model.Email);
                if (exists.StatusCode == StatusCode.EXISTS)
                    return exists;

                var (user, credentials) = UserFactory.Create(model);

                var result = await _repository.CreateUserWithCredentialsAsync(user, credentials);
                if (result.StatusCode != StatusCode.OK)
                    return result;

                return ResponseFactory.Ok("User created successfully.");
            }
            catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
        }

        public async Task<ResponseResult> SignInUserAsync(SignInModel model)
        {
            try
            {
                var userEntity = await _repository.GetUserAndIncludeCredentialsAsync(x => x.Email == model.Email);
                if (userEntity != null)
                {
                    var credentialEntity = userEntity.Credentials.FirstOrDefault();
                    var generatedHash = PasswordHasher.GenerateSecurePassword(model.Password);
                    if (credentialEntity != null && PasswordHasher.ValidateSecurePassword(model.Password, credentialEntity.HashedPassword, credentialEntity.Salt, credentialEntity.SecurityKey))
                    {
                        return ResponseFactory.Ok();
                    }
                }

                return ResponseFactory.Error("Incorrect email or password");
            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }
    }
}
