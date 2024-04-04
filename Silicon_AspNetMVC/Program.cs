using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Helpers.Middlewares;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Silicon_AspNetMVC.Configurations;


namespace Silicon_AspNetMVC;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddHttpClient();

        builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
        builder.Services.RegisterServices(builder.Configuration);

        builder.Services.AddDefaultIdentity<UserEntity>(x =>
        {
            x.User.RequireUniqueEmail = true;
            x.SignIn.RequireConfirmedAccount = false;
            x.Password.RequiredLength = 8;
            x.Lockout.MaxFailedAccessAttempts = 3;
        })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DataContext>();

        builder.Services.ConfigureApplicationCookie(x =>
        {
            x.Cookie.HttpOnly = true;
            x.LoginPath = "/signin";
            x.LogoutPath = "/signout";
            x.AccessDeniedPath = "/denied";
            x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            x.SlidingExpiration = true;
            x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        });

        builder.Services.AddAuthorization(x =>
        {
            x.AddPolicy("SuperUser", policy => policy.RequireRole("SuperUser"));
            x.AddPolicy("AuthenticatedUsers", policy => policy.RequireRole("SuperUser", "User"));
        });

        builder.Services.AddAuthentication().AddFacebook(x => {
            x.AppId = "1050945166008168";
            x.AppSecret = "8931cf2456fb589d5a8a968f489be5c0";
            x.Fields.Add("first_name");
            x.Fields.Add("last_name");
        });

        builder.Services.AddAuthentication().AddGoogle(x => {
            x.ClientId = "871403104408-3qnretnk4vvejte5totml0h9adjjrp0l.apps.googleusercontent.com";
            x.ClientSecret = "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";
            x.CallbackPath = "/signin-google";
        });

        var app = builder.Build();
        app.UseHsts();

        // Added a dollar-sign here. 
        app.UseStatusCodePagesWithReExecute("/Error/PageNotFound", $"?statusCode={0}");
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseUserSessionValidation();

        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = ["SuperUser", "User"];
            foreach (var role in roles)
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
        }

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
