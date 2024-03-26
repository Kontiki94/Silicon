namespace Infrastructure.Models.Sections;

public class AccountSecurityModel
{

    public string Password { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
    public bool DeleteAccount { get; set; } = false;
}
