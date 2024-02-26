using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels;

public class AccountDetailsBasicInfoViewModel
{
    public AccountDetailsBasicInfoModel Account { get; set; } = new AccountDetailsBasicInfoModel()
    {
        FirstName = "Ted",
        LastName = "Pieplow",
        Email = "ted@domain.se",
        ProfileImage = "/images/john-doe.png"
    };
}
