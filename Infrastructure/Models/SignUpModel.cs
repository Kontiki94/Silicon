using Infrastructure.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class SignUpModel
{
    [Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "Required")]
    [MinLength(2, ErrorMessage = "Invalid")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "Required")]
    [MinLength(2, ErrorMessage = "Invalid")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
    [Required(ErrorMessage = "Required")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Required")]
    [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}$", ErrorMessage = "Password not strong enough")]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm password", Prompt = "Confirm password", Order = 4)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Confirm your password")]
    [Compare(nameof(Password), ErrorMessage = "Password does not match")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Terms and conditions", Order = 5)]
    [CheckboxRequired(ErrorMessage = "Accept the terms and conditions to proceed")]
    public bool TermsAndConditions { get; set; } = false;
}
