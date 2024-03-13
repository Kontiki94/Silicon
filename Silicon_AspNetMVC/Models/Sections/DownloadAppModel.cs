using Silicon_AspNetMVC.Models.Components;

namespace Silicon_AspNetMVC.Models.Sections;

public class DownloadAppModel
{
    public string? StoreName {  get; set; }
    public string? Title { get; set; }
    public string? Rating { get; set; }
    public string? LinkUrl { get; set; }

    public ImageViewModel Image { get; set; } = new();
}
