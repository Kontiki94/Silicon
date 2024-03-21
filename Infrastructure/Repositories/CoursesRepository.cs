using Infrastructure.Context;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class CoursesRepository(DataContext context) : Repo<CoursesEntity>(context)
{
    private readonly DataContext _context = context;
}
