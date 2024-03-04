using Infrastructure.Models.Sections;
using Silicon_AspNetMVC.Models.Sections;
using Silicon_AspNetMVC.ViewModels.Account;
namespace Silicon_AspNetMVC.ViewModels.CompositeViewModels;

public class AccountViewModel
{
    public AccountDetailsBasicInfoModel Details { get; set; }
    public AccountDetailsAddressInfoModel AddressInfo { get; set; }
    public SavedCoursesViewModel SavedCourses { get; set; }
    public NavigationViewModel Navigation { get; set; }
    public AccountDeleteViewModel Delete { get; set; } = null!;
    public AccountChangePasswordViewModel ChangePass { get; set; } = null!;


    public AccountViewModel()
    {
        var basicInfoViewModel = new AccountDetailsBasicInfoViewModel();
        Details = basicInfoViewModel.Account;

        var addressInfoViewModel = new AccountDetailsAddressInfoViewModel();
        AddressInfo = addressInfoViewModel.Address;

        new AccountSecurityViewModel()
        {
            ChangePass = ChangePass,
            Delete = Delete
        };

        SavedCourses = new SavedCoursesViewModel();

        Navigation = new NavigationViewModel();
    }
}
