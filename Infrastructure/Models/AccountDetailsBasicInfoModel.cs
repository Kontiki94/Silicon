using System.ComponentModel.DataAnnotations;

namespace Silicon_AspNetMVC.Models.Sections;

public class AccountDetailsBasicInfoModel
{
    public string? ProfileImage { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string? Bio { get; set; }
    public bool IsExternalAccount { get; set; }
}
