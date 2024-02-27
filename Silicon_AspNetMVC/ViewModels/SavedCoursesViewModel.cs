using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels
{
    public class SavedCoursesViewModel
    {
        public string Title { get; set; } = "Saved Items";

        public AccountDetailsBasicInfoModel Account { get; set; } = new AccountDetailsBasicInfoModel()
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@domain.se",
            ProfileImage = "/images/john-doe.png"
        };

        public CourseDetailsModel CourseDetails { get; set; } = new CourseDetailsModel()
        {
            CourseImage = new () {ImageUrl="/images/video-game-design.svg", AltText ="" },
            Title = "Blender Character Creator v2.0 for Video Games Design",
            Author = new () { AuthorName= "Ralph Edwards" },
            Price = (decimal?)18.99,
            ViewHours = 160,
            Likes = "92% (3.1K)"

        };
    }
}
