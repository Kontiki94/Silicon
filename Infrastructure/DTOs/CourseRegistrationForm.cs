
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs;

public class CourseRegistrationForm
{
    [Required]
    [Display(Name = "Title")]
    public string Title { get; set; } = null!;
    [Display(Name = "Price")]
    public string? Price { get; set; }
    [Display(Name = "Discount Price")]
    public string? DiscountPrice { get; set; }
    [Display(Name = "Course Image")]
    public string? CourseImage { get; set; }
    [Display(Name = "Rating")]
    public string? Rating { get; set; }
    [Display(Name = "Reviews")]
    public string? Reviews { get; set; }
    [Display(Name = "Views")]
    public string? Views { get; set; }
    [Display(Name = "Likes")]
    public string? Likes { get; set; }
    [Display(Name = "View hours")]
    public string? ViewHours { get; set; }
    [Display(Name = "Author Name")]
    public string? AuthorName { get; set; }
}
