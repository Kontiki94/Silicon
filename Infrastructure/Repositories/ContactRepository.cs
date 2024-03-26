
using Infrastructure.Context;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class ContactRepository(DataContext context) : Repo<ContactEntity>(context)
{
    private readonly DataContext _context = context;
}
