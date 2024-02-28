using Infrastructure.Entitys;
using Infrastructure.Helpers;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class UserFactory
{
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
		}
		catch { }
        return null!;
    }

    public static (UserEntity, UserCredentialsEntity) Create(SignUpModel model)
    {
        try
        {
            var date = DateTime.Now;
            var user = new UserEntity()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Created = date,
                Updated = date
            };


            UserCredentialsEntity credentials = PasswordHasher.GenerateSecurePassword(model.Password);
            credentials.Id = Guid.NewGuid().ToString();
            credentials.UserId = user.Id;
            user.Credentials = new List<UserCredentialsEntity> { credentials };

            return (user, credentials);
        }
        catch { }
        return (null!, null!);
    }
}
