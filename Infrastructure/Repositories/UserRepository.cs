using Infrastructure.Contexts;
using Infrastructure.Entitys;
using Infrastructure.Models;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class UserRepository(DataContext context) : Repo<UserEntity>(context)
{
    private readonly DataContext _context = context;

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

