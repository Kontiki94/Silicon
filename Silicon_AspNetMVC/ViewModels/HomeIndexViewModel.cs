using Silicon_AspNetMVC.Models.Components;
using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels;

public class HomeIndexViewModel
{
    public string Title { get; set; } = null!;
    public ShowcaseModel Showcase { get; set; } = new ShowcaseModel
    {
        Id = "overview",
        ShowcaseImage = new() { ImageUrl = "images/showcase-task.svg", AltText = "Image of program" },
        Title = "Task Management Assistant You're Gonna Love",
        Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
        Link = new() { ControllerName = "Downloads", ActionName = "Index", Text = "Get started for free" },
        BrandsText = "Largest companies use our tool to work efficiently",
        Brands =
        [
            new() { ImageUrl = "images/brand-logoipsum-1.svg", AltText = "Image brand 1" },
            new() { ImageUrl = "images/brand-logoipsum-2.svg", AltText = "Image brand 2" },
            new() { ImageUrl = "images/brand-logoipsum-3.svg", AltText = "Image brand 3" },
            new() { ImageUrl = "images/brand-logoipsum-4.svg", AltText = "Image brand 4" }
        ]
    };
}
