using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<ContactEntity> Contact { get; set; }
    public DbSet<CoursesEntity> Courses { get; set; }
    public DbSet<SubscribeEntity> Subscribe { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>()
            .HavePrecision(10, 2);
        base.ConfigureConventions(configurationBuilder);
    }
}
