using Silicon_AspNetMVC.Helpers;
using Silicon_AspNetMVC.Models.Sections;
using System.ComponentModel.DataAnnotations;

namespace Silicon_AspNetMVC.ViewModels.Account;

public class AccountDetailsBasicInfoViewModel
{
    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "John", Order = 0)]
    [MinLength(2, ErrorMessage = "Not valid.")]
    [Required(ErrorMessage = "Required")]
    public string FirstName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Doe", Order = 1)]
    [MinLength(2, ErrorMessage = "Not valid.")]
    [Required(ErrorMessage = "Required")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.ImageUrl)]
    public string? ProfileImage { get; set; }

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Email", Order = 2)]
    [Required(ErrorMessage = "Required")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone", Prompt = "Phone number", Order = 3)]
    public string? Phone { get; set; }

    [DataType(DataType.Text)]
    [Display(Name = "Bio", Prompt = "Add a short Bio", Order = 4)]
    public string? Bio {  get; set; }

    public bool IsExternalAccount { get; set; }

    public AccountDetailsBasicInfoViewModel() { }

    public AccountDetailsBasicInfoViewModel(AccountDetailsBasicInfoModel model)
    {
        FirstName = model.FirstName;
        LastName = model.LastName;
        ProfileImage = model.ProfileImage!;
        Email = model.Email;
        Phone = model.Phone;
        Bio = model.Bio;
        IsExternalAccount = model.IsExternalAccount;
    }
}
