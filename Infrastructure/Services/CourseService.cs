using Infrastructure.Contexts;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace Infrastructure.Services;

public class CourseService(HttpClient http, IConfiguration configuration, DataContext context)
{
    private readonly HttpClient _http = http;
    private readonly IConfiguration _configuration = configuration;
    private readonly DataContext _context = context;

    public async Task<CourseResult> GetCoursesAsync(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 10)
    {
        var apiResponse = await _http.GetAsync($"{_configuration["ApiUris:Courses"]}?category={Uri.UnescapeDataString(category)}&searchQuery={Uri.UnescapeDataString(searchQuery)}&key={_configuration["ApiKey:Secret"]}&pageNumber={pageNumber}&pageSize={pageSize}");
        if (apiResponse.IsSuccessStatusCode)
        {
            var json = await apiResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CourseResult>(json);
            if (result!.Courses != null && result.Succeeded)
                return result;

        }

        return null!;
    }

    public async Task<CourseResult> GetSavedCoursesAsync(string userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        var savedCourseIds = user!.SavedCourseIds;
        if (user != null && savedCourseIds != null)
        {
            var courseIdList = savedCourseIds.ToList();
            if (courseIdList.Count > 0)
            {

                var json = JsonConvert.SerializeObject(savedCourseIds);
                using var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _http.PostAsync($"https://localhost:7091/api/courses?key={_configuration["ApiKey:Secret"]}", content);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var courses = JsonConvert.DeserializeObject<IEnumerable<CoursesModel>>(apiResponse);
                    return new CourseResult
                    {
                        Succeeded = true,
                        Courses = courses,
                    };
                }
            }
            return new CourseResult
            {
                Succeeded = false,
                Courses = null!
            };
        }
        return new CourseResult
        {
            Succeeded = false,
            Courses = null!
        };
    }
}
