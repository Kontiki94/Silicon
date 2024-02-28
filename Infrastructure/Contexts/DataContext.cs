using Infrastructure.Entities.HomeEntities;
using Infrastructure.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<AddressEntity> Address { get; set; }
    public DbSet<UserCredentialsEntity> UserCredentials { get; set; }
    public DbSet<ManageWorkEntity> ManageWork { get; set; }
    public DbSet<DarkLightEntity> DarkLight { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
