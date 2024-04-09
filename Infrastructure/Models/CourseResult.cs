namespace Infrastructure.Models;

public class CourseResult
{
    public bool Succeeded { get; set; }
    public bool Exists { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<CoursesModel>? Courses { get; set; }
    public IEnumerable<CoursesModel>? SavedCourses { get; set; }
}
