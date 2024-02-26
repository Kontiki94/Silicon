using Silicon_AspNetMVC.Models.Sections;
namespace Silicon_AspNetMVC.ViewModels.CompositeViewModels;

public class AccountViewModel
{
    public AccountDetailsBasicInfoModel Details {  get; set; }
    public AccountDetailsAddressInfoModel AddressInfo { get; set; }

    public AccountViewModel()
    {
        var basicInfoViewModel = new AccountDetailsBasicInfoViewModel();
        Details = basicInfoViewModel.Account;

        var addressInfoViewModel = new AccountDetailsAddressInfoViewModel();
        AddressInfo = addressInfoViewModel.Address;
    }
}
