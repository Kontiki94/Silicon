
using Infrastructure.Models;

namespace Silicon_AspNetMVC.ViewModels.Auth;

public class SignUpViewModel
{
    public string Title { get; set; } = "Sign Up";
    public SignUpModel Form { get; set; } = new SignUpModel();
}
