using Infrastructure.Contexts;
using Infrastructure.Entitys;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class UserRepository(DataContext context) : Repo<UserEntity>(context)
{
    private readonly DataContext _context = context;

    public async Task<ResponseResult> CreateUserWithCredentialsAsync(UserEntity user, UserCredentialsEntity credentials)
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

    public async Task<UserEntity?> GetUserAndIncludeCredentialsAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        return await _context.Users
            .Include(u => u.Credentials)
            .FirstOrDefaultAsync(predicate);
    }
}

