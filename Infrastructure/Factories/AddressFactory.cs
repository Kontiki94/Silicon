using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class AddressFactory
{
    public static AddressEntity Create()
    {
        try
        {
            return new AddressEntity();
        }
        catch { }
        return null!;
    }

    public static AddressEntity Create(string userId, string adressLine1, string? addressLine2, string postalCode, string city)
    {
        try
        {
            return new AddressEntity
            {
                UserId = userId,
                AddressLine1 = adressLine1,
                AddressLine2 = addressLine2 ?? "",
                PostalCode = postalCode,
                City = city,
            };
        }
        catch { }
        return null!;
    }

    public static AddressEntity Create(string adressLine1, string? addressLine2, string postalCode, string city)
    {
        try
        {
            return new AddressEntity
            {

                AddressLine1 = adressLine1,
                AddressLine2 = addressLine2 ?? "",
                PostalCode = postalCode,
                City = city,
            };
        }
        catch { }
        return null!;
    }

    public static AddressEntity Update(AddressEntity existingEntity, AddressModel model)
    {
        try
        {
            existingEntity.AddressLine1 = model.AddressLine1;
            existingEntity.AddressLine2 = model.AddressLine2;
            existingEntity.PostalCode = model.PostalCode;
            existingEntity.City = model.City;

            return existingEntity;
        }
        catch { }
        return null!;
    }

    public static AddressModel Create(string id, string adressLine1, string? addressLine2, string postalCode, string city, string userId)
    {
        try
        {
            return new AddressModel
            {
                Id = id,
                AddressLine1 = adressLine1,
                AddressLine2 = addressLine2 ?? "",
                PostalCode = postalCode,
                City = city,
                UserId = userId
            };
        }
        catch { }
        return null!;
    }

    public static AddressModel Create(AddressEntity entity)
    {
        try
        {
            return new AddressModel
            {
                Id = entity.Id,
                AddressLine1 = entity.AddressLine1,
                AddressLine2 = entity.AddressLine2 ?? "",
                PostalCode = entity.PostalCode,
                City = entity.City,
                UserId = entity.UserId.ToString()
            };
        }
        catch { }
        return null!;
    }

    public static UserAddressEntity Create(string userId, string addressId)
    {
        try
        {
            return new UserAddressEntity
            {
                UserId = userId,
                AddressId = addressId
            };
        }
        catch { }
        return null!;
    }
}
