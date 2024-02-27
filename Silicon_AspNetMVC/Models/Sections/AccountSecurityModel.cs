using System.ComponentModel.DataAnnotations;

namespace Silicon_AspNetMVC.Models.Sections;

public class AccountSecurityModel
{

    [Display(Name = "Current Password", Prompt = "******", Order = 0)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Required")]
    public string Password { get; set; } = null!;

    [Display(Name = "New Password", Prompt = "******", Order = 1)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Required")]
    [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}$", ErrorMessage = "Password not strong enough")]
    public string NewPassword { get; set; } = null!;

    [Display(Name = "Confirm New password", Prompt = "******", Order = 2)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Confirm your new password")]
    [Compare(nameof(NewPassword), ErrorMessage = "Password does not match")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Delete", Order = 3)]
    public bool DeleteAccount { get; set; } = false;

}
