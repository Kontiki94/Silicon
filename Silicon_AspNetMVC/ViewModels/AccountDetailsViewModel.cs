using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels;

public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account details";
    public AccountModel Account { get; set; } = new AccountModel();
}
