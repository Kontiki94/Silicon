using System.ComponentModel.DataAnnotations;

namespace Silicon_AspNetMVC.Models.Sections;

public class AccountModel
{
    [DataType(DataType.ImageUrl)]
    public string? ProfileImage { get; set; }

    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "John", Order = 0)]
    [Required(ErrorMessage = "Required")]
    public string FirstName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Doe", Order = 1)]
    [Required(ErrorMessage = "Required")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Email", Order = 2)]
    [Required(ErrorMessage = "Required")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone", Prompt = "Phone number", Order = 3)]
    [Required(ErrorMessage = "Required")]
    public string Phone { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Bio", Prompt = "Add a short Bio", Order = 4)]
    public string? Bio { get; set; }

    [DataType(DataType.Text)]
    [Display(Name = "Address Line 1", Prompt = "Enter your address line ", Order = 5)]
    [Required(ErrorMessage = "Required")]
    public string AddressLine1 { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Address Line 2", Prompt = "Enter your second address line ", Order = 6)]
    public string? AddressLine2 { get; set; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Required")]
    [Display(Name = "City", Prompt = "Enter your city", Order = 7)]
    public string City { get; set; } = null!;

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Required")]
    [Display(Name = "Postal Code", Prompt = "Postal code", Order = 8)]
    public string PostalCode { get; set; } = null!;
}
