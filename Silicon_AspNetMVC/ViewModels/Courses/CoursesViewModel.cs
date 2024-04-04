using Infrastructure.Models;

namespace Silicon_AspNetMVC.ViewModels.Courses;

public class CoursesViewModel
{
    public IEnumerable<CategoryModel>? Categories { get; set; }
    public IEnumerable<CoursesModel>? AllCourses { get; set; }
    public Pagination? Pagination { get; set; }
    public string? ErrorMessage { get; set; }
}
