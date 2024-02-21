using System.ComponentModel.DataAnnotations;

namespace Silicon_AspNetMVC.Models.Sections;

public class AccountModel
{
    [DataType(DataType.ImageUrl)]
    public string? ProfileImage { get; set; }

    [Display(Name = "First name", Prompt = "John", Order = 0)]
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last name", Prompt = "Doe", Order = 1)]
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "john.doe@domain.com", Order = 2)]
    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone", Prompt = "Enter your phone number", Order = 3)]
    public string Phone { get; set; } = null!;

    [Display(Name = "Bio", Prompt = "Add a short Bio", Order = 4)]
    public string? Bio { get; set; }

    [Display(Name = "Address Line 1", Prompt = "Enter your address line ", Order = 5)]
    [Required(ErrorMessage = "Address line is required")]
    public string AddressLine1 { get; set; } = null!;

    [Display(Name = "Address Line 2", Prompt = "Enter your second address line ", Order = 6)]
    public string? AddressLine2 { get; set; }

    [Required(ErrorMessage = "City is required")]
    [Display(Name = "City", Prompt = "Enter your city", Order = 7)]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "Postal code is required")]
    [Display(Name = "Postal Code", Prompt = "Enter your postal code", Order = 8)]
    public string PostalCode { get; set; } = null!;
}
