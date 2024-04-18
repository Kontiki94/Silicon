namespace Infrastructure.Models;

public class CourseResult
{
    public bool Succeeded { get; set; }
<<<<<<< HEAD
    public bool Exists { get; set; }
=======
>>>>>>> 5093d5ff2a66cda979cdb5cac84ee5629d1021ef
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<CoursesModel>? Courses { get; set; }
    public IEnumerable<CoursesModel>? SavedCourses { get; set; }
}
