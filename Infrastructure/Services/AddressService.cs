using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class AddressService(AddressRepository addressRepository)
{
    private readonly AddressRepository _addressRepository = addressRepository;

    public async Task <ResponseResult> CreateAddressAsync()
    {
		try
		{

		}
		catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
}
