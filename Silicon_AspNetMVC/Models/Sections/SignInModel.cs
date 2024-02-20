using System.ComponentModel.DataAnnotations;

namespace Silicon_AspNetMVC.Models.Sections;

public class SignInModel
{
    [Display(Name = "Email", Prompt = "Enter your email", Order = 0)]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [Compare(nameof(Password), ErrorMessage = "Password does not match")]
    public string Password { get; set; } = null!;

    [Display(Name = "RememberMe")]
    public bool RememberMe { get; set; }
}
