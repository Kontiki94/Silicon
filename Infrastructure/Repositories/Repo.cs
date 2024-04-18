<<<<<<< HEAD
﻿using Infrastructure.Contexts;
=======
﻿using Infrastructure.Context;
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
<<<<<<< HEAD

=======
using System.Reflection.Metadata.Ecma335;
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
namespace Infrastructure.Repositories;

public abstract class Repo<TEntity>(DataContext context) where TEntity : class
{
    private readonly DataContext _context = context;

<<<<<<< HEAD
    public virtual async Task<ResponseResult> CreateOneAsync(TEntity entity)
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

=======
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


>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
    public virtual async Task<ResponseResult> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
<<<<<<< HEAD
            if (result is null)
            {
                return ResponseFactory.NotFound();
            }
            return ResponseFactory.Ok(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public virtual async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            var result = await _context.Set<TEntity>().ToListAsync();               //IEnumerable<TEntity> ? 
            return ResponseFactory.Ok();                                            //Skicka tillbaks result? return ResponseFactory.Ok(result)
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public virtual async Task<ResponseResult> UpdateOneAsync(Expression<Func<TEntity, bool>> predicate, TEntity updatedEntity)
=======
            if (result is not null)
            {
                return ResponseFactory.Ok(result, "Retrieved successfully");
            }
        }
        catch (Exception) {  }
        return null!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        try
        {
            var result = await _context.Set<TEntity>().ToListAsync();
            return result;
        }
        catch (Exception)
        {
            return null!;
        }
    }

    public virtual async Task<ResponseResult> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity entityToUpdate)
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result is not null)
            {
<<<<<<< HEAD
                _context.Entry(result).CurrentValues.SetValues(updatedEntity);
=======
                _context.Entry(result).CurrentValues.SetValues(entityToUpdate);
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok(result);
            }

            return ResponseFactory.NotFound();
        }
<<<<<<< HEAD
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public virtual async Task<ResponseResult> DeleteOneAsync(Expression<Func<TEntity, bool>> predicate)
=======
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }

    public virtual async Task<bool> DeleteOneAsync(Expression<Func<TEntity, bool>> predicate)
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result is not null)
            {
                _context.Set<TEntity>().Remove(result);
                await _context.SaveChangesAsync();
<<<<<<< HEAD
                return ResponseFactory.Ok("Successfully removed.");
            }
            return ResponseFactory.NotFound();
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public virtual async Task<ResponseResult> AlreadyExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().AnyAsync(predicate);
            if (result)
                return ResponseFactory.Exists();

            return ResponseFactory.NotFound();
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }
}





=======
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
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
