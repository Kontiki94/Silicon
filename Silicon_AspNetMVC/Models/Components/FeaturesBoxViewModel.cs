namespace Silicon_AspNetMVC.Models.Components;

public class FeaturesBoxViewModel
{
    public string? BoxTitle { get; set; }
    public string? BoxText { get; set; }
    public ImageViewModel BoxImage { get; set; } = new ImageViewModel();
    public LinkViewModel? Link { get; set; }
}
