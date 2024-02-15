using Silicon_AspNetMVC.Models.Components;

namespace Silicon_AspNetMVC.Models.Sections;

public class CoursesViewModel
{
    public string? Id { get; set; }
    public string? CourseTitle { get; set; }
    public ImageViewModel CourseImage { get; set; } = null!;
    public string? Author { get; set; }
    public decimal? Price { get; set; }
    public decimal? Views { get; set; }
    public List<string>? Categories { get; set; }
    public LinkViewModel Link { get; set; } = new LinkViewModel();
}
