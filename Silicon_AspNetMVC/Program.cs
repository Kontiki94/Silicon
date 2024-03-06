using Infrastructure.Contexts;
using Infrastructure.Entitys;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Silicon_AspNetMVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddAuthentication("AuthCookie").AddCookie("AuthCookie", x =>
        {
            x.LoginPath = "/signin";
            x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            x.SlidingExpiration = true;
        });

        builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
        builder.Services.AddScoped<AddressRepository>();
        builder.Services.AddScoped<AddressService>();
        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddDefaultIdentity<UserEntity>(x =>
        {
            x.User.RequireUniqueEmail = true;
            x.SignIn.RequireConfirmedAccount = false;
            x.Password.RequiredLength = 8;
        }).AddEntityFrameworkStores<DataContext>();

        var app = builder.Build();
        app.UseHsts();
        app.UseStatusCodePagesWithReExecute("/Error/PageNotFound", "?statusCode={0}");
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
