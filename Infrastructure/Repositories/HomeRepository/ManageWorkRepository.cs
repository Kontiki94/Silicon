using Infrastructure.Contexts;
using Infrastructure.Entities.HomeEntities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories.HomeRepository;

public class ManageWorkRepository(DataContext context) : Repo<ManageWorkEntity>(context)
{
    private readonly DataContext _context = context;

    public override async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            IEnumerable<ManageWorkEntity> result = await _context.ManageWork.ToListAsync();
            return ResponseFactory.Ok(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }
}
