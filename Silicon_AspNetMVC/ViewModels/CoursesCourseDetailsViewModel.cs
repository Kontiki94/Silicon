using Silicon_AspNetMVC.Models.Components;
using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels;

public class CoursesCourseDetailsViewModel
{
    public string Title { get; set; } = null!;

    public CourseDetailsModel CourseDetails = new()
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
            Youtube = "240K",
            Facebook = "180K",
            AuthorImage = new() { ImageUrl = "/images/albert-flores.svg", AltText = "Picture of author" }
        },
        CourseDescription = "Suspendisse natoque sagittis, consequat turpis. Sed tristique tellus morbi magna. At vel senectus accumsan, arcu mattis id tempor. Tellus sagittis, euismod porttitor sed tortor est id. Feugiat velit velit, tortor ut. Ut libero cursus nibh lorem urna amet tristique leo. Viverra lorem arcu nam nunc at ipsum quam. A proin id sagittis dignissim mauris condimentum ornare. Tempus mauris sed dictum ultrices.",
        LearnPoints =
        [
            "Sed lectus donec amet eu turpis interdum.",
            "Nulla at consectetur vitae dignissim porttitor.",
            "Phasellus id vitae dui aliquet mi.",
            "Integer cursus vitae, odio feugiat iaculis aliquet diam, et purus.",
            "In aenean dolor diam tortor orci eu."
        ],
        DiscountPrice = (decimal)28.99,
        Price = (decimal)49.00,
        ProgramDetails =
        [
            new SectionTitleModel { Title = "Introduction. Getting started", Subtitle = "Nulla faucibus mauris pellentesque blandit faucibus non. Sit ut et at suspendisse gravida hendrerit tempus placerat." },
            new SectionTitleModel { Title = "The ultimate HTML developer: advanced HTML", Subtitle = "Lobortis diam elit id nibh ultrices sed penatibus donec. Nibh iaculis eu sit cras ultricies. Nam eu eget etiam egestas donec scelerisque ut ac enim. Vitae ac nisl, enim nec accumsan vitae est." },
            new SectionTitleModel { Title = "CSS & CSS3: basic", Subtitle = "Duis euismod enim, facilisis risus tellus pharetra lectus diam neque. Nec ultrices mi faucibus est. Magna ullamcorper potenti elementum ultricies auctor nec volutpat augue." },
            new SectionTitleModel { Title = "JavaScript basics for beginners", Subtitle = "Morbi porttitor risus imperdiet a, nisl mattis. Amet, faucibus eget in platea vitae, velit, erat eget velit. At lacus ut proin erat." },
            new SectionTitleModel { Title = "Understanding APIs", Subtitle = "Risus morbi euismod in congue scelerisque fusce pellentesque diam consequat. Nisi mauris nibh sed est morbi amet arcu urna. Malesuada feugiat quisque consectetur elementum diam vitae. Dictumst facilisis odio eu quis maecenas risus odio fames bibendum." },
            new SectionTitleModel { Title = "C# and .NET from beginner to advanced", Subtitle = "Quis risus quisque diam diam. Volutpat neque eget eu faucibus sed urna fermentum risus. Est, mauris morbi nibh massa." }

        ]
    };

    public AuthorViewModel Author = new()
    {
        Id = 1,
        AuthorName = "Albert Flores",
        AuthorImage = { ImageUrl = "/images/albert-flores.svg", AltText = "Portrait of Albert" },
        Description = "Dolor ipsum amet cursus quisque porta adipiscing. Lorem convallis malesuada sed maecenas. Ac dui at vitae mauris cursus in nullam porta sem. Quis pellentesque elementum ac bibendum. Nunc aliquam in tortor facilisis. Vulputate eget risus, metus phasellus. Pellentesque faucibus amet, eleifend diam quam condimentum convallis ultricies placerat. Duis habitasse placerat amet, odio pellentesque rhoncus, feugiat at. Eget pellentesque tristique felis magna fringilla.",
        Youtube = "240K",
        Facebook = "180k"
    };
}
