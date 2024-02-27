namespace Silicon_AspNetMVC.ViewModels
{
    public class PageNotFoundViewModel
    {
        public string ImageUrl { get; set; } = null!;
        public string AltText { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ButtonIcon { get; set; } = null!;
        public string ButtonText { get; set; } = null!;

        public PageNotFoundViewModel()
        {
            ImageUrl = "images/404.svg";
            AltText = "404-image";
            Title = "Ooops!";
            Description = "The page you are looking for is not available";
            ButtonIcon = "fa-regular fa-house";
            ButtonText = "Go to homepage";
        }
    }
}
