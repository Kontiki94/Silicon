using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.Models.Views;

public class CoursesCourseDetailsViewModel
{
    public string Title { get; set; } = null!;

    public CourseDetailsViewModel CourseDetails = new CourseDetailsViewModel
    {
        Id = "course-details",
        CourseImage = new() { ImageUrl = "/images/laptop-image.svg", AltText = "Image of laptop" },
        Title = "Fullstack Web Developer Course From Scratch",
        Subtitle = "Egestas feugiat lorem eu neque suspendisse ullamcorper scelerisque aliquam mauris",
        Rating = "1.2K",
        Likes = "5K",
        ViewHours = 148,
        Author = 
        {
            AuthorName = "Albert Flores", 
            Description = "Dolor ipsum amet cursus quisque porta adipiscing. Lorem convallis malesuada sed maecenas. Ac dui at vitae mauris cursus in nullam porta sem. Quis pellentesque elementum ac bibendum. Nunc aliquam in tortor facilisis. Vulputate eget risus, metus phasellus. Pellentesque faucibus amet, eleifend diam quam condimentum convallis ultricies placerat. Duis habitasse placerat amet, odio pellentesque rhoncus, feugiat at. Eget pellentesque tristique felis magna fringilla.", 
            Youtube="240K", 
            Facebook = "180K", 
            AuthorImage = new() { ImageUrl = "/images/albert-flores.svg", AltText = "Picture of author"} 
        }
    };
}
