using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Infrastructure.Services;

public class CourseService(HttpClient http, IConfiguration configuration, DataContext context, UserManager<UserEntity> userManager)
{
    private readonly HttpClient _http = http;
    private readonly IConfiguration _configuration = configuration;
    private readonly DataContext _context = context;
    private readonly UserManager<UserEntity> _userManager = userManager;

    public async Task<CourseResult> GetCoursesAsync(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 10)
    {
        try
        {
            var apiResponse = await _http.GetAsync($"{_configuration["ApiUris:Courses"]}/all?category={Uri.UnescapeDataString(category)}&searchQuery={Uri.UnescapeDataString(searchQuery)}&key={_configuration["ApiKey:Secret"]}&pageNumber={pageNumber}&pageSize={pageSize}");
            if (apiResponse.IsSuccessStatusCode)
            {
                var json = await apiResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CourseResult>(json);
                if (result!.Courses != null && result.Succeeded)
                    return result;
            }
        }
        catch (Exception) { }
        return new CourseResult { Succeeded = false };
    }

    public async Task<CourseResult> SaveCourseIdAsync(int courseId, ClaimsPrincipal user)
    {
        try
        {
            var currentUser = await _userManager.GetUserAsync(user);

            if (currentUser != null && currentUser.SavedCourseIds != null)
            {
                if (!currentUser.SavedCourseIds.Contains(courseId))
                {
                    currentUser.SavedCourseIds!.Add(courseId);
                    await _userManager.UpdateAsync(currentUser);
                    return new CourseResult { Succeeded = true };
                }
                return new CourseResult { Exists = true };
            }
        }
        catch (Exception) { }
        return new CourseResult { Succeeded = false };
    }

    public async Task<CourseResult> GetSavedCoursesAsync(string userId)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var savedCourseIds = user?.SavedCourseIds;
            if (user != null && savedCourseIds != null && savedCourseIds.Any())
            {
                var apiKey = _configuration["ApiKey:Secret"];
                var url = $"https://localhost:7091/api/Courses/saved?key={apiKey}";

                var queryParams = savedCourseIds.Select(id => $"savedCourseIds={id}");
                if (queryParams.Any())
                {
                    url += "&" + string.Join("&", queryParams);
                }

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CourseResult>(apiResponse);
                    return result!;
                }
            }
        }
        catch (Exception) { }
        return new CourseResult { Succeeded = false };
    }

    public async Task<CourseResult> RemoveOneCourseAsync(int courseId, ClaimsPrincipal user)
    {
        try
        {
            var userEntity = await _userManager.GetUserAsync(user);

            if (userEntity != null)
            {
                userEntity.SavedCourseIds!.Remove(courseId);
                await _userManager.UpdateAsync(userEntity);
                return new CourseResult() { Succeeded = true };
            }
        }
        catch (Exception) { }
        return new CourseResult { Succeeded = false };
    }

    public async Task<CourseResult> RemoveAllCoursesAsync(ClaimsPrincipal user)
    {
        try
        {
            var userEntity = await _userManager.GetUserAsync(user);

            if (userEntity != null && userEntity.SavedCourseIds != null)
            {
                userEntity.SavedCourseIds.Clear();
                await _userManager.UpdateAsync(userEntity);
                return new CourseResult() { Succeeded = true };
            }
        }
        catch (Exception) { }
        return new CourseResult { Succeeded = false };
    }
}
