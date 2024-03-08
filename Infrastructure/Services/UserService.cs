using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Models.Sections;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Services
{
    public class UserService(UserRepository repository, AddressService addressService, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        private readonly UserRepository _repository = repository;
        private readonly AddressService _addressService = addressService;
        private readonly UserManager<UserEntity> _userManager = userManager;
        private readonly SignInManager<UserEntity> _signInManager = signInManager;


        public async Task<ResponseResult> CreateUserAsync(SignUpModel model)
        {
            try
            {
                var exists = await _userManager.Users.AnyAsync(x => x.Email == model.Email);
                if (exists)
                {
                    return ResponseFactory.Exists();
                }
                else
                {
                    var newUser = UserFactory.Create(model);
                    var result = await _userManager.CreateAsync(newUser, model.Password);
                    
                    if (result.Succeeded)
                    {
                        return ResponseFactory.Ok();
                    }
                    return ResponseFactory.Error("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }

        public async Task<ResponseResult> SignInUserAsync(SignInModel model)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return ResponseFactory.Ok();
                }
                return ResponseFactory.Error("Incorrect email or password");
            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }

        public async Task<ResponseResult> UpdateCredentials(AccountSecurityModel securityModel, string userEmail)
        {
            try
            {
                var userEntity = await _userManager.FindByEmailAsync(userEmail);
                if (userEntity is null)
                {
                    return ResponseFactory.NotFound();
                }
                else if (userEntity is not null)
                {
                    var result = await _userManager.ChangePasswordAsync(userEntity, securityModel.Password, securityModel.NewPassword);
                    if (result.Succeeded)
                    {
                        return ResponseFactory.Ok();
                    }
                }
                return ResponseFactory.Error("Something went wrong");
            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }

        public async Task<ResponseResult> UpdateUserAsync(UserEntity entity)
        {
            try
            {
                var entityToUpdate = await _repository.UpdateOneAsync(x => x.Email == entity.Email, entity);
                if (entityToUpdate != null)
                {
                    return ResponseFactory.Ok(entityToUpdate);
                }
                return ResponseFactory.Error("Incorrect email or password");
            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }

        public async Task<ResponseResult> DeleteUser(string userEmail)
        {
            try
            {
                var result = await _repository.DeleteOneAsync(x => x.Email == userEmail);
                if (result.StatusCode == StatusCode.OK)
                {
                    return ResponseFactory.Ok();
                }
                else
                {
                    return ResponseFactory.Error("Something went wrong");
                }
            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }
    }
}


