using Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.Services;

public class CourseService(HttpClient http, IConfiguration configuration)
{
    private readonly HttpClient _http = http;
    private readonly IConfiguration _configuration = configuration;

    public async Task<IEnumerable<CoursesModel>> GetCoursesAsync(string category = "", string searchQuery = "")
    {
        var apiResponse = await _http.GetAsync($"{_configuration["ApiUris:Courses"]}?category={Uri.UnescapeDataString(category)}&searchQuery={Uri.UnescapeDataString(searchQuery)}&key={_configuration["ApiKey:Secret"]}");
        if (apiResponse.IsSuccessStatusCode)
        {
            var json = await apiResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CourseResult>(json);
            if (result!.Courses != null && result.Succeeded)
                return result.Courses;
        }

        return null!;
    }
}
