namespace Silicon_AspNetMVC.ViewModels.Account
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? ProfileImageUrl { get; set; } = "john-doe.png";
        public string? AltText { get; set; }
        public NavigationViewModel NavigationViewModel { get; set; } = new NavigationViewModel();
    }
}
