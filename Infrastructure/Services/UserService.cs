﻿using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Models.Sections;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Silicon_AspNetMVC.Models.Sections;
using System.Diagnostics;
using System.Security.Claims;



namespace Infrastructure.Services
{
    public class UserService(UserRepository repository, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, IConfiguration configuration)
    {
        private readonly UserRepository _repository = repository;
        private readonly UserManager<UserEntity> _userManager = userManager;
        private readonly SignInManager<UserEntity> _signInManager = signInManager;
        private readonly IConfiguration _configuration = configuration;


        public async Task<ResponseResult> CreateUserAsync(SignUpModel model)
        {
            try
            {
                var standardRole = "User";

                if (!await _userManager.Users.AnyAsync())
                {
                    standardRole = "SuperUser";
                }

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
                        await _userManager.AddToRoleAsync(newUser, standardRole);
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

        public async Task<ResponseResult> GetUserByIdAsync(string Id)
        {
            try
            {
                var result = await _repository.GetOneAsync(x => x.Id == Id);
                if (result.StatusCode == StatusCode.OK)
                {
                    var userEntity = (UserEntity)result.ContentResult!;
                    var userModel = new AccountDetailsBasicInfoModel()
                    {
                        FirstName = userEntity.FirstName,
                        LastName = userEntity.LastName,
                        Email = userEntity.Email!,
                        Phone = userEntity.PhoneNumber!,
                        Bio = userEntity.Biography
                    };
                    var addressModel = UserFactory.Create(userModel);
                    return new ResponseResult()
                    {
                        StatusCode = result.StatusCode,
                        ContentResult = addressModel,
                    };
                }
                return ResponseFactory.NotFound("Address not found");
            }
            catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
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
                var entityToUpdate = await _repository.UpdateOneAsync(x => x.Id == entity.Id, entity);
                if (entityToUpdate is not null)
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

        public async Task<bool> UploadUserProfileImageAsync(ClaimsPrincipal user, IFormFile file)
        {
            try
            {
                if (user is not null && file is not null && file.Length != 0)
                {
                    var userEntity = await _userManager.GetUserAsync(user);
                    {
                        if (userEntity is not null)
                        {
                            var fileName = $"p_{userEntity.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration["FileUploadPath"]!, fileName);

                            using var fs = new FileStream(filePath, FileMode.Create);
                            await file.CopyToAsync(fs);

                            userEntity.ProfileImageUrl = fileName;
                            var result = await _repository.UpdateAsync(userEntity);
                            if (result.StatusCode == StatusCode.OK)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ResponseFactory.Error(ex.Message);
            }
            return false;
        }
    }
}


