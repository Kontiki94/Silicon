using Infrastructure.Contexts;
using Infrastructure.Entitys;
using Infrastructure.Factories;
using Infrastructure.Models;
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

    public override Task<ResponseResult> GetAllAsync(UserEntity entity)
    {
        // TODO ANSO
        return base.GetAllAsync(entity);
    }

    public override Task<ResponseResult> GetOneAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        // TODO Hassan
        return base.GetOneAsync(predicate);
    }
}

