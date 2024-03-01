using Silicon_AspNetMVC.Models.Components;
using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels.Home;

public class ShowcaseViewModel
{
    public string? Id { get; set; }
    public ImageViewModel ShowcaseImage { get; set; } = null!;
    public string? Title { get; set; }
    public string? Text { get; set; }
    public LinkViewModel Link { get; set; } = new();
    public string? BrandsText { get; set; }
    public List<ImageViewModel>? Brands { get; set; }

    public ShowcaseViewModel() 
    {
        Id = "overview";
        ShowcaseImage = new() { ImageUrl = "images/showcase-task.svg", AltText = "Image of program" };
        Title = "Task Management Assistant You're Gonna Love";
        Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.";
        Link = new() { ControllerName = "Downloads", ActionName = "Index", Text = "Get started for free" };
        BrandsText = "Largest companies use our tool to work efficiently";
        Brands =
    [
        new() { ImageUrl = "images/brand-logoipsum-1.svg", AltText = "Image brand 1" },
        new() { ImageUrl = "images/brand-logoipsum-2.svg", AltText = "Image brand 2" },
        new() { ImageUrl = "images/brand-logoipsum-3.svg", AltText = "Image brand 3" },
        new() { ImageUrl = "images/brand-logoipsum-4.svg", AltText = "Image brand 4" }
    ];
    }
}
