using Infrastructure.Entities;
using Infrastructure.Models;
using Silicon_AspNetMVC.Models.Sections;

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

    public static UserEntity Create(string firstName, string lastName, string email, string phone, string bio, string userId)
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
                Id = userId
            };
        }
        catch { }
        return null!;
    }
}
