using Infrastructure.Context;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
namespace Infrastructure.Repositories;

public abstract class Repo<TEntity>(DataContext context) where TEntity : class
{
    private readonly DataContext _context = context;

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        try
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null!;
        }
    }


    public virtual async Task<ResponseResult> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result is not null)
            {
                return ResponseFactory.Ok(result, "Retrieved successfully");
            }
        }
        catch (Exception) {  }
        return null!;
    }

    public virtual async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            var result = await _context.Set<TEntity>().ToListAsync();
            return ResponseFactory.Ok(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public virtual async Task<ResponseResult> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity entityToUpdate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result is not null)
            {
                _context.Entry(result).CurrentValues.SetValues(entityToUpdate);
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok(result);
            }

            return ResponseFactory.NotFound();
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }

    public virtual async Task<bool> DeleteOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result is not null)
            {
                _context.Set<TEntity>().Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }
}
