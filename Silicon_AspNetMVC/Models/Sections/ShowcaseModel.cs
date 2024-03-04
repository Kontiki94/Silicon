using Silicon_AspNetMVC.Models.Components;

namespace Silicon_AspNetMVC.Models.Sections;

public class ShowcaseModel
{
    public string? Id { get; set; }
    public ImageViewModel ShowcaseImage { get; set; } = null!;
    public string? Title { get; set; }
    public string? Text { get; set; }
    public LinkViewModel Link { get; set; } = new();
    public string? BrandsText { get; set; }
    public List<ImageViewModel>? Brands { get; set; }
}
