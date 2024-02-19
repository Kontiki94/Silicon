namespace Silicon_AspNetMVC.Models.Components;

public class AuthorViewModel
{
    public int? Id { get; set; }
    public string? AuthorName { get; set; }
    public string? Description { get; set; }
    public string? Youtube { get; set; }
    public string? Facebook { get; set; }
    public ImageViewModel AuthorImage { get; set; } = new ImageViewModel();
}
