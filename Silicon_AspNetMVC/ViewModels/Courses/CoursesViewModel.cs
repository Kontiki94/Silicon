using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels.Courses
{
    public class CoursesViewModel
    {
        public string Title { get; set; } = null!;

        public CourseDetailsModel Courses { get; set; } = new CourseDetailsModel
        {
            Title = "Courses",
            Id = "Courses",
            CourseImage = new() { ImageUrl = "/images/fullstack_dev.png", AltText = "Macbook image" },
            Author = new() { AuthorName = "Robert Fox" },
            Price = 23,
            Views = 5000,
            Link = new() { ControllerName = "Courses", ActionName = "CourseDetails" },
            Categories = new List<string> { "IT", "Tech", "DevOps", "Data Analyst" }
        };
    }
}
