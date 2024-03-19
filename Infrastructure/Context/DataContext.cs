

using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Infrastructure.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<AuthorEntity> Author { get; set; }
    public DbSet<ContactEntity> Contact { get; set; }
    public DbSet<CourseEntity> Course { get; set; }
    public DbSet<SubscribeEntity> Subscribe { get; set; }

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
