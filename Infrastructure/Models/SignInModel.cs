using System.ComponentModel.DataAnnotations;


namespace Infrastructure.Models;

public class SignInModel
{
    [Display(Name = "Email", Prompt = "Enter your email.", Order = 0)]
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = "******", Order = 1)]
    [Required(ErrorMessage = "Password is required.")]
    [MinLength(2, ErrorMessage = "Not valid.")]

    public string Password { get; set; } = null!;

    [Display(Name = "RememberMe", Order = 2)]
    public bool RememberMe { get; set; }
}
