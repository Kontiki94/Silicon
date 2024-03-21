using Infrastructure.Context;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class SubscriberRepo(DataContext context) : Repo<SubscribeEntity>(context)
{
    private readonly DataContext _context = context;
}
