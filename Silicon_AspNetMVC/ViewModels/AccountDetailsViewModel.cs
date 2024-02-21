using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels;

public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account details";
    public AccountModel Account { get; set; } = new AccountModel()
    {
        FirstName = "Ted",
        LastName = "Pieplow",
        Email = "ted@domain.se",
        ProfileImage = "/images/john-doe.png"
    };
}
