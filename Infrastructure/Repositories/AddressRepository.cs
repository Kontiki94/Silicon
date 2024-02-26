using Infrastructure.Contexts;
using Infrastructure.Entitys;

namespace Infrastructure.Repositories;

public class AddressRepository(DataContext context) : Repo<AddressEntity>(context)
{
    private readonly DataContext _context = context;
}

