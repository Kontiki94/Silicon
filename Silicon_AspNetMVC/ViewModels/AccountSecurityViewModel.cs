using Silicon_AspNetMVC.Models.Sections;
using Silicon_AspNetMVC.ViewModels.CompositeViewModels;

namespace Silicon_AspNetMVC.ViewModels;

public class AccountSecurityViewModel
{
    public AccountSecurityModel Security { get; set; } = new();
}
