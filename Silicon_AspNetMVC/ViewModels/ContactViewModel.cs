namespace Silicon_AspNetMVC.Models.Sections;

public class ContactViewModel
{
    public string FormTitle { get; set; } = "Get In Contact With Us";

    public ContactFormModel Form { get; set; } = new ContactFormModel();

}
