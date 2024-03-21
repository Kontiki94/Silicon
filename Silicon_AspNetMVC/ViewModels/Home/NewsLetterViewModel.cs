using Infrastructure.Models;
using Silicon_AspNetMVC.Models.Components;

namespace Silicon_AspNetMVC.ViewModels.Home;

public class NewsLetterViewModel
{
    public SectionTitleModel NewsletterTitle { get; set; } = new SectionTitleModel();
    public List<CheckBoxViewModel> Checkbox { get; set; } = [];
    public ImageViewModel NewsletterImage { get; set; } = new ImageViewModel();

    public SubscribeModel Subscriber { get; set; } = new SubscribeModel();

    public NewsLetterViewModel()
    {
        NewsletterTitle.Title = "Don't Want To Miss Anything?";
        NewsletterTitle.Subtitle = "Sign up for Newsletters";
        NewsletterImage.ImageUrl = "images/arrows.svg";
        NewsletterImage.AltText = "Squiggly arrow";
        Checkbox =
            [
                new CheckBoxViewModel() { Id = "daily-newsletter", Text = "Daily Newsletter" },
                new CheckBoxViewModel() { Id = "advertising", Text = "Advertising Updates" },
                new CheckBoxViewModel() { Id = "review", Text = "Week in Review" },
                new CheckBoxViewModel() { Id = "events", Text = "Event Updates" },
                new CheckBoxViewModel() { Id = "startup", Text = "Startups Weekly" },
                new CheckBoxViewModel() { Id = "podcasts", Text = "Podcasts" }
            ];
    }
}
