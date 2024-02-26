using Infrastructure.Contexts;
using Infrastructure.Models;

namespace Infrastructure.Repositories;

public abstract class Repo<TEntity>(DataContext context) where TEntity : class
{
    private readonly DataContext _context = context;

    public virtual async Task<ResponseResult> CreateAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return new ResponseResult
            {
                ContentResult = entity,
                Message = "Created successfully",
                StatusCode = StatusCode.OK
            };
        }
        catch { }
        return null!;
    }
}
