using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories.HomeRepository;

namespace Infrastructure.Services.HomeService;

public class ManageWorkService(ManageWorkRepository repository)
{
    private readonly ManageWorkRepository _repository = repository;

    public async Task<ResponseResult> GetAllManageWork()
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
