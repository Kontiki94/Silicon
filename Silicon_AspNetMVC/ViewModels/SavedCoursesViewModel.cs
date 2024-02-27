using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels
{
    public class SavedCoursesViewModel
    {
        public string Title { get; set; } = "Saved Items";

        public AccountModel AccountSaved { get; set; } = new()
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@domain.se",
            ProfileImage = "/images/john-doe.png"
        };

        public CourseDetailsModel? CourseDetails { get; set; } 
    }
}
