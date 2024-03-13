using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.AccountRepository;

public class AccountDetailsRepository(DataContext context) : Repo<UserEntity>(context) 
{
    private readonly DataContext _context = context;

    public override async Task<ResponseResult> UpdateOneAsync(Expression<Func<UserEntity, bool>> predicate, UserEntity updatedEntity)
    {
        try
        {
            var existingEntity = await _context.Users.FirstOrDefaultAsync(predicate);
            if (existingEntity is not null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok();
            }
            return ResponseFactory.NotFound("User not found");
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error(ex.Message);
        }
    }
}
