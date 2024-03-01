using Infrastructure.Models.Sections;
using Silicon_AspNetMVC.Models.Sections;
using Silicon_AspNetMVC.ViewModels.Account;
namespace Silicon_AspNetMVC.ViewModels.CompositeViewModels;

public class AccountViewModel
{
    public AccountDetailsBasicInfoModel Details {  get; set; }
    public AccountDetailsAddressInfoModel AddressInfo { get; set; }
    public AccountSecurityModel Security { get; set; }
    // Lägg till en model för saved courses.
    public SavedCoursesViewModel SavedCourses { get; set; }
    public NavigationViewModel Navigation { get; set; }


    public AccountViewModel()
    {
        var basicInfoViewModel = new AccountDetailsBasicInfoViewModel();
        Details = basicInfoViewModel.Account;

        var addressInfoViewModel = new AccountDetailsAddressInfoViewModel();
        AddressInfo = addressInfoViewModel.Address;

       var accountSecurityViewModel = new AccountSecurityViewModel();
        Security = accountSecurityViewModel.Security;

        SavedCourses = new SavedCoursesViewModel();

        Navigation = new NavigationViewModel();
    }
}
