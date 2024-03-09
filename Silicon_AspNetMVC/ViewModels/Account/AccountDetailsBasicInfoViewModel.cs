using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels.Account;

public class AccountDetailsBasicInfoViewModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string ProfileImage { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Bio {  get; set; } 

    public AccountDetailsBasicInfoViewModel() { }

    public AccountDetailsBasicInfoViewModel(AccountDetailsBasicInfoModel model)
    {
        FirstName = model.FirstName;
        LastName = model.LastName;
        ProfileImage = model.ProfileImage!;
        Email = model.Email;
        Phone = model.Phone;
        Bio = model.Bio;
    }
}
