using Infrastructure.Repositories;
using Infrastructure.Services;
using Silicon_AspNetMVC.Services;

namespace Silicon_AspNetMVC.Configurations;

public static class ServiceConfiguration
{
    public static void RegisterServices(this  IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AddressRepository>();
        services.AddScoped<AddressService>();
        services.AddScoped<UserRepository>();
        services.AddScoped<UserService>();
        services.AddScoped<ControllerService>();
        services.AddScoped<AuthServices>();
        services.AddScoped<CategoryService>();
        services.AddScoped<CourseService>();
    }
}
