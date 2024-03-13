using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class UserRepository(DataContext context) : Repo<UserEntity>(context)
{
    private readonly DataContext _context = context;
    

    public async Task<ResponseResult> CreateUserWithCredentialsAsync(UserEntity user)
    {
        try
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return ResponseFactory.Ok("User created successfully.");
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }

    public override Task<ResponseResult> GetAllAsync()
    {
        // TODO ANSO
        return base.GetAllAsync();
    }


    public virtual async Task<ResponseResult> UpdateAsync(UserEntity entity)
    {
        try
        {
            var entityToUpdate = _context.Set<UserEntity>().Update(entity).Entity;
            await _context.SaveChangesAsync();
            return ResponseFactory.Ok();
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }

    public virtual async Task<ResponseResult> DeleteAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<UserEntity>()
                .FirstOrDefaultAsync(predicate);
            if (result is not null)
            {
                _context.Set<UserEntity>().Remove(result);
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok("Successfully removed.");
            }
            return ResponseFactory.NotFound();
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }
}

