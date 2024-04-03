using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataSeeds;

public class DbSeeds
{
    public static void Seeder(ModelBuilder builder)
    {
        SeedCourses(builder);
        SeedCategories(builder);
    }

    public static void SeedCourses(ModelBuilder builder)
    {
        builder.Entity<CoursesEntity>().HasData(
            new CoursesEntity()
            {
                Id = 1,
                IsBestSeller = true,
                CourseImage = "course_one",
                CourseImageAltText = "course one",
                Title = "Fullstack Web Developer Course from Scratch",
                AuthorName = "Robert Fox",
                Price = "12.50",
                DiscountPrice = null,
                ViewHours = "220",
                LikesInPercent = "94",
                LikesInNumbers = "4.2",
                CategoryId = 1,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                CourseDescription = "Suspendisse natoque sagittis, consequat turpis. Sed tristique tellus morbi magna. At vel senectus accumsan, arcu mattis id tempor. Tellus sagittis, euismod porttitor sed tortor est id. Feugiat velit velit, tortor ut. Ut libero cursus nibh lorem urna amet tristique leo. Viverra lorem arcu nam nunc at ipsum quam. A proin id sagittis dignissim mauris condimentum ornare. Tempus mauris sed dictum ultrices.",
                Reviews = "1.2",
                AuthorImage = "albert-flores.svg",
                AutherImageAltText = "Albert Flores image",
                LearnPoints = new List<string>
                {
                    "Sed lectus donec amet eu turpis interdum.",
                    "Nulla at consectetur vitae dignissim porttitor.",
                    "Phasellus id vitae dui aliquet mi.",
                    "Integer cursus vitae, odio feugiat iaculis aliquet diam, et purus.",
                    "In aenean dolor diam tortor orci eu."
                },
                Articles = "18",
                Resources = "25",
                AccessTime = "Full lifetime access",
                ProgramDetailsTitle = new List<string>
                {
                    "Introduction. Getting started",
                    "The ultimate HTML developer: advanced HTML",
                    "CSS & CSS3: basic",
                    "JavaScript basics for beginners",
                    "Understanding APIs",
                    "C# and .NET from beginner to advanced",
                },
                ProgramDetailsText = new List<string>
                {
                    "Nulla faucibus mauris pellentesque blandit faucibus non. Sit ut et at suspendisse gravida hendrerit tempus placerat.",
                    "Lobortis diam elit id nibh ultrices sed penatibus donec. Nibh iaculis eu sit cras ultricies. Nam eu eget etiam egestas donec scelerisque ut ac enim. Vitae ac nisl, enim nec accumsan vitae est.",
                    "Duis euismod enim, facilisis risus tellus pharetra lectus diam neque. Nec ultrices mi faucibus est. Magna ullamcorper potenti elementum ultricies auctor nec volutpat augue.",
                    "Morbi porttitor risus imperdiet a, nisl mattis. Amet, faucibus eget in platea vitae, velit, erat eget velit. At lacus ut proin erat.",
                    "Risus morbi euismod in congue scelerisque fusce pellentesque diam consequat. Nisi mauris nibh sed est morbi amet arcu urna. Malesuada feugiat quisque consectetur elementum diam vitae. Dictumst facilisis odio eu quis maecenas risus odio fames bibendum.",
                    "Quis risus quisque diam diam. Volutpat neque eget eu faucibus sed urna fermentum risus. Est, mauris morbi nibh massa.",
                },
                AutherBio = "Dolor ipsum amet cursus quisque porta adipiscing. Lorem convallis malesuada sed maecenas. Ac dui at vitae mauris cursus in nullam porta sem. Quis pellentesque elementum ac bibendum. Nunc aliquam in tortor facilisis. Vulputate eget risus, metus phasellus. Pellentesque faucibus amet, eleifend diam quam condimentum convallis ultricies placerat. Duis habitasse placerat amet, odio pellentesque rhoncus, feugiat at. Eget pellentesque tristique felis magna fringilla.",
                FaceBookFollowers = "240",
                YouTubeSubscribers = "180"
            },
            new CoursesEntity()
            {
                Id = 2,
                IsBestSeller = false,
                CourseImage = "course_two",
                CourseImageAltText = "course two",
                Title = "HTML, CSS, JavaScript Web Developer",
                AuthorName = "Jenny Wilson & Marvin McKinney",
                Price = "15.99",
                DiscountPrice = null,
                ViewHours = "160",
                LikesInPercent = "92",
                LikesInNumbers = "3.1",
                CategoryId = 2,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            },
            new CoursesEntity()
            {
                Id = 3,
                IsBestSeller = false,
                CourseImage = "course_three",
                CourseImageAltText = "course three",
                Title = "The Complete Front-End Web Development Course",
                AuthorName = "Albert Flores",
                Price = "44.99",
                DiscountPrice = "9.99",
                ViewHours = "100",
                LikesInPercent = "98",
                LikesInNumbers = "2.7",
                CategoryId = 6,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            },
            new CoursesEntity()
            {
                Id = 4,
                IsBestSeller = false,
                CourseImage = "course_four",
                CourseImageAltText = "course four",
                Title = "iOS & Swift - The Complete iOS App Development Course",
                AuthorName = "Marvin McKinney",
                Price = "15.99",
                DiscountPrice = null,
                ViewHours = "220",
                LikesInPercent = "92",
                LikesInNumbers = "3.1",
                CategoryId = 5,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            },
            new CoursesEntity()
            {
                Id = 5,
                IsBestSeller = true,
                CourseImage = "course_five",
                CourseImageAltText = "course five",
                Title = "Data Science & Machine Learning with Python",
                AuthorName = "Esther Howard",
                Price = "12.50",
                DiscountPrice = null,
                ViewHours = "220",
                LikesInPercent = "94",
                LikesInNumbers = "4.2",
                CategoryId = 3,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            },
            new CoursesEntity()
            {
                Id = 6,
                IsBestSeller = false,
                CourseImage = "course_six",
                CourseImageAltText = "course six",
                Title = "Creative CSS Drawing Course: Make Art With CSS",
                AuthorName = "Robert Fox",
                Price = "10.50",
                DiscountPrice = null,
                ViewHours = "220",
                LikesInPercent = "94",
                LikesInNumbers = "4.2",
                CategoryId = 2,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            },
            new CoursesEntity()
            {
                Id = 7,
                IsBestSeller = false,
                CourseImage = "course_seven",
                CourseImageAltText = "course seven",
                Title = "Blender Character Creator v2.0 for Video Games Design",
                AuthorName = "Ralph Edwards",
                Price = "18.99",
                DiscountPrice = null,
                ViewHours = "160",
                LikesInPercent = "92",
                LikesInNumbers = "3.1",
                CategoryId = 4,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            },
            new CoursesEntity()
            {
                Id = 8,
                IsBestSeller = false,
                CourseImage = "course_eight",
                CourseImageAltText = "course eight",
                Title = "The Ultimate Guide to 2D Mobile Game Development with Unity",
                AuthorName = "Albert Flores",
                Price = "44.99",
                DiscountPrice = "12.99",
                ViewHours = "100",
                LikesInPercent = "98",
                LikesInNumbers = "2.7",
                CategoryId = 4,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            },
            new CoursesEntity()
            {
                Id = 9,
                IsBestSeller = false,
                CourseImage = "course_nine",
                CourseImageAltText = "course nine",
                Title = "Learn JMETER from Scratch on Live Apps-Performance Testing",
                AuthorName = "Jenny Wilson",
                Price = "14.50",
                DiscountPrice = null,
                ViewHours = "160",
                LikesInPercent = "92",
                LikesInNumbers = "3.1",
                CategoryId = 5,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            });
    }

    public static void SeedCategories(ModelBuilder builder)
    {
        builder.Entity<CategoryEntity>().HasData(
            new CategoryEntity()
            {
                Id = 1,
                CategoryName = "Web Development"
            },
            new CategoryEntity()
            {
                Id = 2,
                CategoryName = "HTML & CSS"
            },
            new CategoryEntity()
            {
                Id = 3,
                CategoryName = "Python"
            },
            new CategoryEntity()
            {
                Id = 4,
                CategoryName = "Game Development"
            },
            new CategoryEntity()
            {
                Id = 5,
                CategoryName = "App Development"
            },
            new CategoryEntity()
            {
                Id = 6,
                CategoryName = "Frontend Development"
            });
    }
}
