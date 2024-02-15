namespace Silicon_AspNetMVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();

        var app = builder.Build();
        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "courses",
            pattern: "{controller=Courses}/{action=CoursesIndex}/{id?}");
        
        app.MapControllerRoute(
            name: "signin",
            pattern: "{controller=SignIn}/{action=SignInIndex}/{id?}");

        app.Run();
    }
}
