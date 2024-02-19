using Silicon_AspNetMVC.Models.Components;
using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.Models.Views;

public class CoursesCourseDetailsViewModel
{
    public string Title { get; set; } = null!;

    public CourseDetailsViewModel CourseDetails = new()
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
        },
        CourseDescription = "Suspendisse natoque sagittis, consequat turpis. Sed tristique tellus morbi magna. At vel senectus accumsan, arcu mattis id tempor. Tellus sagittis, euismod porttitor sed tortor est id. Feugiat velit velit, tortor ut. Ut libero cursus nibh lorem urna amet tristique leo. Viverra lorem arcu nam nunc at ipsum quam. A proin id sagittis dignissim mauris condimentum ornare. Tempus mauris sed dictum ultrices.",
        LearnPoints =
        [
            "Sed lectus donec amet eu turpis interdum.",
            "Nulla at consectetur vitae dignissim porttitor.",
            "Phasellus id vitae dui aliquet mi.",
            "Integer cursus vitae, odio feugiat iaculis aliquet diam, et purus.",
            "In aenean dolor diam tortor orci eu."
        ]
    };

    public AuthorViewModel Author = new()
    {
        Id = 1,
        AuthorName = "Albert Flores",
        AuthorImage = { ImageUrl = "/images/albert-flores.svg", AltText = "Portrait of Albert"},
        Description = "Dolor ipsum amet cursus quisque porta adipiscing. Lorem convallis malesuada sed maecenas. Ac dui at vitae mauris cursus in nullam porta sem. Quis pellentesque elementum ac bibendum. Nunc aliquam in tortor facilisis. Vulputate eget risus, metus phasellus. Pellentesque faucibus amet, eleifend diam quam condimentum convallis ultricies placerat. Duis habitasse placerat amet, odio pellentesque rhoncus, feugiat at. Eget pellentesque tristique felis magna fringilla.",
        Youtube = "240K",
        Facebook = "180k"
    };
}
