using Silicon_AspNetMVC.Models.Sections;
using Silicon_AspNetMVC.ViewModels.CompositeViewModels;

namespace Silicon_AspNetMVC.ViewModels.Account;

public class AccountSecurityViewModel
{
    public AccountSecurityModel Security { get; set; } = new();
}
