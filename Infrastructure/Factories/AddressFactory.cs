using Infrastructure.Entitys;

namespace Infrastructure.Factories;

public class AddressFactory
{
    public static AddressEntity Create()
    {
        try
        {
            return new AddressEntity();
        }
        catch (Exception) { }
        return null!;
    }

    public static AddressEntity Create(string streetName, string postalCode, string city)
    {
		try
		{
			return new AddressEntity
			{
				StreetName = streetName,
				PostalCode = postalCode,
				City = city
			};
		}
		catch (Exception) {}
		return null!;
    }
}
