using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels.Contact;

public class ContactViewModel
{
    public string FormTitle { get; set; } = "Get In Contact With Us";
    public string? SuccessMessage { get; set; }
    public string? ErrorMessage { get; set; }
    public ContactFormModel Form { get; set; } = new ContactFormModel();

}
