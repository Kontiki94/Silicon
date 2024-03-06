using Infrastructure.Entitys;
using Infrastructure.Models;
using Infrastructure.Models.Sections;

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
}
