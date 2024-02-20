using Silicon_AspNetMVC.Models.Components;

namespace Silicon_AspNetMVC.Models.Sections;

public class CourseDetailsModel
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Subtitle { get; set; }
    public ImageViewModel CourseImage { get; set; } = null!;
    public string? Rating { get; set; }
    public int? Reviews { get; set; }
    public decimal? Views { get; set; }
    public string? Likes { get; set; }
    public int? ViewHours { get; set; }
    public decimal? Price { get; set; }
    public decimal? DiscountPrice { get; set; }
    public int? Articles { get; set; }
    public int? Resources { get; set; }
    public string? AccessTime { get; set; }
    public string? CourseDescription { get; set; }
    public List<string>? LearnPoints { get; set; }
    public List<SectionTitleModel>? ProgramDetails { get; set; }
    public List<string>? Categories { get; set; }
    public AuthorViewModel Author { get; set; } = new AuthorViewModel();
    public LinkViewModel Link { get; set; } = new LinkViewModel();
}
