using Infrastructure.Entities;
using Infrastructure.Models.Sections;
using Silicon_AspNetMVC.Models.Sections;
using Silicon_AspNetMVC.ViewModels.Account;
namespace Silicon_AspNetMVC.ViewModels.CompositeViewModels;

public class AccountViewModel
{
    public UserEntity User { get; set; }
    public AccountDetailsBasicInfoViewModel Details { get; set; }
    public AccountDetailsAddressInfoViewModel AddressInfo { get; set; }
    public SavedCoursesViewModel SavedCourses { get; set; }
    public NavigationViewModel Navigation { get; set; }
    public AccountDeleteViewModel Delete { get; set; } = null!;
    public AccountChangePasswordViewModel ChangePass { get; set; } = null!;


    public AccountViewModel()
    {
        User ??= new UserEntity();
        Details = new AccountDetailsBasicInfoViewModel();
        AddressInfo = new AccountDetailsAddressInfoViewModel();

        new AccountSecurityViewModel()
        {
            ChangePass = ChangePass,
            Delete = Delete
        };

        SavedCourses = new SavedCoursesViewModel();

        Navigation = new NavigationViewModel();
    }
}
