using Azure.Identity;
using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using System.Linq.Expressions;

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
            return ResponseFactory.Ok(entity);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public virtual async Task<ResponseResult> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        // TODO Hassan
    }

    public virtual async Task<ResponseResult> GetAllAsync(TEntity entity)
    {
        // TODO Ann-Sofie
    }

    
}
