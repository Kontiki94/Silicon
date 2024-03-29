using Infrastructure.Entities;
using Infrastructure.Helpers;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class UserFactory
{
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
                    Salt = userEntity.Salt,
                    Password = userEntity.Password,
                    SecurityKey = userEntity.SecurityKey
                };
            }
        }
        catch { }
        return null!;
    }
}
