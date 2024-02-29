using Silicon_AspNetMVC.Models.Components;

namespace Silicon_AspNetMVC.ViewModels.Home;
public class FeaturesViewModel
{
    public string Title { get; set; } = null!;
    public string Subtitle { get; set; } = null!;
    public List<FeaturesBoxViewModel> Boxes { get; set; } = null!;

    public FeaturesViewModel()
    {
        Title = "What do you get with our tool?";
        Subtitle = "Make sure all your tasks are organized so you can set the priorities and focus on important.";

        Boxes = 
        [
            new FeaturesBoxViewModel() { BoxImage = { ImageUrl = "images/icons/chat-icon.svg", AltText = ""}, BoxTitle = "Comments on Tasks", BoxText = "Id mollis consectetur congue egestas egestas suspendisse blandit justo." },
            new FeaturesBoxViewModel() { BoxImage = { ImageUrl = "images/icons/task-analytics-icon.svg", AltText = "" }, BoxTitle = "Tasks Analytics", BoxText = "Non imperdiet facilisis nulla tellus Morbi scelerisque eget adipiscing vulputate." },
            new FeaturesBoxViewModel() { BoxImage = { ImageUrl = "images/icons/assignment-icon.svg", AltText = "" }, BoxTitle = "Multiple Assignees", BoxText = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris." },
            new FeaturesBoxViewModel() { BoxImage = { ImageUrl = "images/icons/notification-icon.svg", AltText = "" }, BoxTitle = "Notifications", BoxText = "Diam, suspendisse velit cras ac. Lobortis diam volutpat, eget pellentesque viverra." },
            new FeaturesBoxViewModel() { BoxImage = { ImageUrl = "images/icons/section-subtask-icon.svg", AltText = "" }, BoxTitle = "Sections & Subtasks", BoxText = "Mi feugiat hac id in. Sit elit placerat lacus nibh lorem ridiculus lectus." },
            new FeaturesBoxViewModel() { BoxImage = { ImageUrl = "images/icons/data-security-icon.svg", AltText = "" }, BoxTitle = "Data Security", BoxText = "Aliquam malesuada neque eget elit nulla vestibulum nunc cras." }
        ];
    }
}
