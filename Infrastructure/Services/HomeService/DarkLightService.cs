using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories.HomeRepository;

namespace Infrastructure.Services.HomeService;

public class DarkLightService(DarkLightRepository repository)
{
    private readonly DarkLightRepository _repository = repository;

    public async Task<ResponseResult> GetAllDarkLightAsync()
    {
        try
        {
            var result = await _repository.GetAllAsync();
            return result;
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }
}
