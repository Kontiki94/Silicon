using Infrastructure.Entities;

namespace Infrastructure.Models;

public class CoursesModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? CourseImage { get; set; }
    public string? Rating { get; set; }
    public string? Reviews { get; set; }
    public string? Views { get; set; }
    public string? Likes { get; set; }
    public string? ViewHours { get; set; }
    public string? AuthorName { get; set; }

    public static implicit operator CoursesModel(CoursesEntity coursesEntity)
    {
        return new CoursesModel
        {
            Id = coursesEntity.Id,
            Title = coursesEntity.Title,
            Price = coursesEntity.Price,
            DiscountPrice = coursesEntity.DiscountPrice,
            CourseImage = coursesEntity.CourseImage,
            Rating = coursesEntity.Rating,
            Reviews = coursesEntity.Reviews,
            Views = coursesEntity.Views,
            Likes = coursesEntity.Likes,
            ViewHours = coursesEntity.ViewHours,
            AuthorName = coursesEntity.AuthorName
        };
    }
}
