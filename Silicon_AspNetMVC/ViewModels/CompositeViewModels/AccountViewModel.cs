using Infrastructure.Entities;
using Silicon_AspNetMVC.ViewModels.Account;
namespace Silicon_AspNetMVC.ViewModels.CompositeViewModels;

public class AccountViewModel
{
    public UserEntity User { get; set; }
    public ProfileViewModel Profile { get; set; }
    public AccountDetailsBasicInfoViewModel Details { get; set; }
    public AccountDetailsAddressInfoViewModel AddressInfo { get; set; }
    public SavedCoursesViewModel SavedCourses { get; set; }
    public NavigationViewModel Navigation { get; set; }
    public AccountDeleteViewModel Delete { get; set; } = null!;
    public AccountChangePasswordViewModel ChangePass { get; set; } = null!;
    public string SuccessMessage { get; set; }
    public string ErrorMessage { get; set; }


    public AccountViewModel()
    {
        User ??= new UserEntity();
        Profile = new ProfileViewModel();
        Details = new AccountDetailsBasicInfoViewModel();
        AddressInfo = new AccountDetailsAddressInfoViewModel();
        SuccessMessage = "";
        ErrorMessage = "";

        new AccountSecurityViewModel()
        {
            ChangePass = ChangePass,
            Delete = Delete
        };

        SavedCourses = new SavedCoursesViewModel();

        Navigation = new NavigationViewModel();
    }
}
