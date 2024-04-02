
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs;

public class CourseRegistrationForm
{
    [Required]
    [Display(Name = "Title")]
    public string Title { get; set; } = null!;
    [Display(Name = "IsBestSeller")]
    public bool IsBestSeller { get; set; } = false;
    [Display(Name = "CourseImage")]
    public string? CourseImage { get; set; }
    [Display(Name = "CourseImageAltText")]
    public string? CourseImageAltText { get; set; }
    [Display(Name = "Price")]
    public string? Price { get; set; }
    [Display(Name = "DiscountPrice")]
    public string? DiscountPrice { get; set; }
    [Display(Name = "Rating")]
    public string? Rating { get; set; }
    [Display(Name = "Reviews")]
    public string? Reviews { get; set; }
    [Display(Name = "Views")]
    public string? Views { get; set; }
    [Display(Name = "LikesInPercent")]
    public string? LikesInPercent { get; set; }
    [Display(Name = "LikesInNumbers")]
    public string? LikesInNumbers { get; set; }


    // AutherInfo
    [Display(Name = "AuthorName")]
    public string? AuthorName { get; set; }
    [Display(Name = "AutherBio")]
    public string? AutherBio { get; set; }
    [Display(Name = "AuthorImage")]
    public string? AuthorImage { get; set; }
    [Display(Name = "AutherImageAltText")]
    public string? AutherImageAltText { get; set; }
    [Display(Name = "YouTubeSubscribers")]
    public string? YouTubeSubscribers { get; set; }
    [Display(Name = "FaceBookFollowers")]
    public string? FaceBookFollowers { get; set; }


    // CourseDetails
    [Display(Name = "CourseDescription")]
    public string? CourseDescription { get; set; }
    [Display(Name = "ViewHours")]
    public string? ViewHours { get; set; }
    [Display(Name = "Articles")]
    public string? Articles { get; set; }
    [Display(Name = "Resources")]
    public string? Resources { get; set; }
    [Display(Name = "AccessTime")]
    public string? AccessTime { get; set; }
    [Display(Name = "Program Details Title")]
    public List<string>? ProgramDetailsTitle { get; set; }
    [Display(Name = "Program Details Text")]
    public List<string>? ProgramDetailsText { get; set; }
    [Display(Name = "Learn Points")]
    public List<string>? LearnPoints { get; set; }
    [Display(Name = "Categories")]
    public string? Category { get; set; }
}
