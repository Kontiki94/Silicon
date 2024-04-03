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
                DiscountPrice = "",
                ViewHours = "220",
                LikesInPercent = "94",
                LikesInNumbers = "4.2",
                CategoryId = 1,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
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
                DiscountPrice = "",
                ViewHours = "160",
                LikesInPercent = "92",
                LikesInNumbers = "3.1",
                CategoryId = 2,
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
                DiscountPrice = "",
                ViewHours = "220",
                LikesInPercent = "92",
                LikesInNumbers = "3.1",
                CategoryId = 5,
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
                DiscountPrice = "",
                ViewHours = "220",
                LikesInPercent = "94",
                LikesInNumbers = "4.2",
                CategoryId = 3,
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
                DiscountPrice = "",
                ViewHours = "220",
                LikesInPercent = "94",
                LikesInNumbers = "4.2",
                CategoryId = 2,
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
                DiscountPrice = "",
                ViewHours = "160",
                LikesInPercent = "92",
                LikesInNumbers = "3.1",
                CategoryId = 4,
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
                DiscountPrice = "",
                ViewHours = "160",
                LikesInPercent = "92",
                LikesInNumbers = "3.1",
                CategoryId = 5,
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
