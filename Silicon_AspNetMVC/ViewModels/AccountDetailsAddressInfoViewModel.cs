using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels
{
    public class AccountDetailsAddressInfoViewModel
    {
        public AccountDetailsAddressInfoModel Address { get; set; } = new AccountDetailsAddressInfoModel()
        {
            AddressLine1 = "",
            AddressLine2 = "",
            PostalCode = "",
            City = ""
        };
    }
}
