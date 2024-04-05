using Infrastructure.DTOs;


namespace Infrastructure.Entities;

public class CoursesEntity
{
    // GeneralCourseInfo
    public int Id { get; set; }
    public bool IsBestSeller { get; set; } = false;
    public string? CourseImage { get; set; }
    public string? CourseImageAltText { get; set; }
    public string Title { get; set; } = null!;
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string? Rating { get; set; }
    public string? Reviews { get; set; }
    public string? Views { get; set; }
    public string? LikesInPercent { get; set; }
    public string? LikesInNumbers { get; set; }
    public DateTime Created {  get; set; }
    public DateTime Updated {  get; set; }

    // AutherInfo
    public string? AuthorName { get; set; }
    public string? AutherBio { get; set; }
    public string? AuthorImage { get; set; }
    public string? AutherImageAltText { get; set; }
    public string? YouTubeSubscribers { get; set; }
    public string? FaceBookFollowers { get; set; }

    // CourseDetails
    public string? ShowcaseImage { get; set; }
    public string? CourseDescription { get; set; }
    public string? ViewHours { get; set; }
    public string? Articles { get; set; }
    public string? Resources { get; set; }
    public string? AccessTime { get; set; }
    public List<string>? ProgramDetailsTitle { get; set; }
    public List<string>? ProgramDetailsText { get; set; }
    public List<string>? LearnPoints { get; set; }
    public int? CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }

    // Implicit type converter
    public static implicit operator CoursesEntity(CourseRegistrationForm DTO)
    {
        var courseEntity = new CoursesEntity
        {
            Title = DTO.Title,
            IsBestSeller = DTO.IsBestSeller,
            CourseImage = DTO.CourseImage,
            CourseImageAltText = DTO.CourseImageAltText,
            Price = DTO.Price,
            DiscountPrice = DTO.DiscountPrice,
            Rating = DTO.Rating,
            Reviews = DTO.Reviews,
            Views = DTO.Views,
            LikesInPercent = DTO.LikesInPercent,
            LikesInNumbers = DTO.LikesInNumbers,
            AuthorName = DTO.AuthorName,
            AutherBio = DTO.AutherBio,
            AuthorImage = DTO.AuthorImage,
            AutherImageAltText = DTO.AutherImageAltText,
            YouTubeSubscribers = DTO.YouTubeSubscribers,
            FaceBookFollowers = DTO.FaceBookFollowers,
            CourseDescription = DTO.CourseDescription,
            ViewHours = DTO.ViewHours,
            Resources = DTO.Resources,
            AccessTime = DTO.AccessTime,
            ProgramDetailsTitle = DTO.ProgramDetailsTitle,
            ProgramDetailsText = DTO.ProgramDetailsText,
            LearnPoints = DTO.LearnPoints,
        };

        if (DTO.Category != null)
        {
            courseEntity.Category = new CategoryEntity
            {
                CategoryName = DTO.Category,
            };
        }

        return courseEntity;
    }
}


