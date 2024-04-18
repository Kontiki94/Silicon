using System.ComponentModel.DataAnnotations;

namespace Silicon_AspNetMVC.Models.Sections;

public class ContactModel
{

    [DataType(DataType.Text)]
    [Display(Name = "Full name", Prompt = "Enter your full name", Order = 0)]
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 1)]
    [Required(ErrorMessage = "Email address is required")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;
   
    [Display(Name = "Service (Optional)", Prompt = "Choose the service you are interested in...", Order = 2)]
    public string? Service { get; set; }

    [DataType(DataType.MultilineText)]
    [Display(Name = "Message", Prompt = "Enter your message here", Order = 3)]
    [Required(ErrorMessage = "Message is required")]
    [StringLength (200, MinimumLength = 2, ErrorMessage = "Your message must be minimum 2 characters and can be maximum 200 characters")]
    public string Message { get; set; } = null!;

}
