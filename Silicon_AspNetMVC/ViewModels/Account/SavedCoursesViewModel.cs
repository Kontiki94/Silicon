using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels.Account
{
    public class SavedCoursesViewModel
    {
        public string Title { get; set; } = "Saved Items";

        public CoursesModel Course { get; set; } = new CoursesModel()
        {
            CourseImage = "/images/video-game-design.svg",
            Title = "Blender Character Creator v2.0 for Video Games Design",
            AuthorName = "Ralph Edwards",
            Price = "18.99",
            ViewHours = "160",
            LikesInPercent = "92%",
            LikesInNumbers = "(3.1K)"
        };
    }
}
