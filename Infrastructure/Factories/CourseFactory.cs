using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class CourseFactory
{
    public static CoursesModel Create(CoursesEntity entity)
    {
        try
        {
            var courseModel = new CoursesModel
            {
                Id = entity.Id,
                Title = entity.Title,
                IsBestSeller = entity.IsBestSeller,
                CourseImage = entity.CourseImage,
                CourseImageAltText = entity.CourseImageAltText,
                Price = entity.Price,
                DiscountPrice = entity.DiscountPrice,
                Rating = entity.Rating,
                Reviews = entity.Reviews,
                Views = entity.Views,
                LikesInPercent = entity.LikesInPercent,
                LikesInNumbers = entity.LikesInNumbers,
                AuthorName = entity.AuthorName,
                AutherBio = entity.AutherBio,
                AuthorImage = entity.AuthorImage,
                AutherImageAltText = entity.AutherImageAltText,
                YouTubeSubscribers = entity.YouTubeSubscribers,
                FaceBookFollowers = entity.FaceBookFollowers,
                CourseDescription = entity.CourseDescription,
                ViewHours = entity.ViewHours,
                Resources = entity.Resources,
                AccessTime = entity.AccessTime,
                LearnPoints = entity.LearnPoints,
                ProgramDetailsText = entity.ProgramDetailsText,
                ProgramDetailsTitle = entity.ProgramDetailsTitle,
            };

            if (entity.Category != null)
            {
                courseModel.Category = entity.Category.CategoryName;
            }

            return courseModel;
        }
        catch { }
        return null!;
    }

    public static IEnumerable<CoursesModel> Create(List<CoursesEntity> entities)
    {

        List<CoursesModel> courses = new List<CoursesModel>();
        try
        {
            foreach (var entity in entities)
            {
                courses.Add(Create(entity));
            }
        }
        catch (Exception) { }
        return courses;
    }
}
