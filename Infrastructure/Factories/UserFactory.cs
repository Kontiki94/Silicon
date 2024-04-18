using Infrastructure.Entities;
<<<<<<< HEAD
using Infrastructure.Models;
using Silicon_AspNetMVC.Models.Sections;
=======
using Infrastructure.Helpers;
using Infrastructure.Models;
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef

namespace Infrastructure.Factories;

public class UserFactory
{
<<<<<<< HEAD
    public static UserEntity Create()
    {
        try
        {
            var date = DateTime.Now;

            return new UserEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Created = date,
                Updated = date
            };
=======
    public static UserEntity Create(UserRegistrationForm form)
    {
        try
        {
            var userEntity = PasswordHasher.GenerateSecurePassword(form.Password);

            if (userEntity != null)
            {
                return new UserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    Email = form.Email,
                    Password = form.Password,
                    HashedPassword = userEntity.HashedPassword,
                    Salt = userEntity.Salt,
                    SecurityKey = userEntity.SecurityKey
                };
            }
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
        }
        catch { }
        return null!;
    }
<<<<<<< HEAD

    public static UserEntity Create(AccountDetailsBasicInfoModel model)
    {
        try
        {
            var date = DateTime.Now;

            return new UserEntity()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                Created = date,
                Updated = date
            };
        }
        catch { }
        return null!;
    }

    public static UserEntity Create(SignUpModel model)
    {
        try
        {
            var date = DateTime.Now;

            return new UserEntity()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                Created = date,
                Updated = date
            };
        }
        catch { }
        return null!;
    }

    public static UserEntity Create(string firstName, string lastName, string email, string phone, string bio, string userId, string passwordHash, string normalizedEmail, string normalizedUserName, string userName, string profileImage)
    {
        try
        {
            var date = DateTime.Now;

            return new UserEntity()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
                PhoneNumber = phone,
                Biography = bio,
                Created = date,
                Updated = date,
                Id = userId,
                ProfileImageUrl = profileImage,
                PasswordHash = passwordHash,
                NormalizedEmail = email,
                NormalizedUserName = email,
            };
        }
        catch { }
        return null!;
    }


=======
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
}
