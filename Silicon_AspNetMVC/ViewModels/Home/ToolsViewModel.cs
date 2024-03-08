using Silicon_AspNetMVC.Models.Components;

namespace Silicon_AspNetMVC.ViewModels.Home;

public class ToolsViewModel
{
    public string? Id { get; set; }
    public SectionTitleModel SectionTitle { get; set; } = new SectionTitleModel();
    public List<FeaturesBoxViewModel>? ToolBoxes { get; set; }
    public LinkViewModel? Link { get; set; }

    public ToolsViewModel() 
    {
        Id = "tools";
        SectionTitle.Title = "Integrate Top Work Tools";
        SectionTitle.Subtitle = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin volutpat mollis egestas. Nam luctus facilisis ultrices. Pellentesque volutpat ligula est. Mattis fermentum, at nec lacus.";

        ToolBoxes =
        [
            new FeaturesBoxViewModel() { BoxImage = { ImageUrl = "images/icons/google-icon.svg", AltText = "google icon" }, BoxText = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis.", Link = new() { ControllerName = "", ActionName ="" } },
            new FeaturesBoxViewModel() { BoxImage = { ImageUrl = "images/icons/zoom-icon.svg", AltText = "zoom icon" }, BoxText = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis.", Link = new() { ControllerName = "", ActionName = "" } },
            new FeaturesBoxViewModel() { BoxImage = { ImageUrl = "images/icons/slack-icon.svg", AltText = "slack icon" }, BoxText = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis.", Link = new() { ControllerName = "", ActionName = "" } },
            new FeaturesBoxViewModel() { BoxImage = { ImageUrl = "images/icons/gmail-icon.svg", AltText = "gmail icon" }, BoxText = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis.", Link = new() { ControllerName = "", ActionName = "" } },
            new FeaturesBoxViewModel() { BoxImage = { ImageUrl = "images/icons/trello-icon.svg", AltText = "trello icon" }, BoxText = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis.", Link = new() { ControllerName = "", ActionName = "" } },
            new FeaturesBoxViewModel() { BoxImage = { ImageUrl = "images/icons/mailchimp-icon.svg", AltText = "mailchimp icon" }, BoxText = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis.", Link = new() { ControllerName = "", ActionName = "" } },
            new FeaturesBoxViewModel() { BoxImage = { ImageUrl = "images/icons/dropbox-icon.svg", AltText = "dropbox icon" }, BoxText = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis.", Link = new() { ControllerName = "", ActionName = "" } },
            new FeaturesBoxViewModel() { BoxImage = { ImageUrl = "images/icons/evernote-icon.svg", AltText = "evernote icon" }, BoxText = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis.", Link = new() { ControllerName = "", ActionName = "" } }

        ];
    }

}
