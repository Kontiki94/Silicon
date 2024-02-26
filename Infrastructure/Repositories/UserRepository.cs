using Infrastructure.Contexts;
using Infrastructure.Entitys;

namespace Infrastructure.Repositories;

public class UserRepository(DataContext context) : Repo<UserEntity>(context)
{
    private readonly DataContext _context = context;
}

