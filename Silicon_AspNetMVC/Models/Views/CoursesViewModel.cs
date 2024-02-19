using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.Models.Views
{
    public class CoursesViewModel
    {
        public string Title { get; set; } = null!;

        public CourseDetailsViewModel Courses = new CourseDetailsViewModel
        {
            Id = "courses",
            Title = "Fullstack Web Developer Course from Scratch",
            CourseImage = new() { ImageUrl = "/images/fullstack_dev.png", AltText = "Macbook image" },
            Author =
            {
                AuthorName = "Robert Fox"
            },
            Price = 23,
            Views = 5000,
            Link = new() { ControllerName = "Courses", ActionName = "CourseDetails" },
            Categories =
                [
                    "IT",
                    "Tech",
                    "DevOps",
                    "Data Analyst"
                    ],
        };
    }
}
