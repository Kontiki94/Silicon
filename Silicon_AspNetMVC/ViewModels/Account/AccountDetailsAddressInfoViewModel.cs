using Infrastructure.Models;

namespace Silicon_AspNetMVC.ViewModels.Account;

public class AccountDetailsAddressInfoViewModel
{
    public string Id { get; set; } = "";
    public string AddressLine1 { get; set; } = "";
    public string AddressLine2 { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string City { get; set; } = "";

    public AccountDetailsAddressInfoViewModel() { }

    public AccountDetailsAddressInfoViewModel(AddressModel model)
    {
        Id = model.Id ?? "";
        AddressLine1 = model.AddressLine1 ?? "";
        AddressLine2 = model.AddressLine2 ?? "";
        PostalCode = model.PostalCode ?? "";
        City = model.City ?? "";
    }
}

