using Infrastructure.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Silicon_AspNetMVC.ViewModels.Account;

public class AccountDeleteViewModel
{
    [Display(Name = "Delete")]
    [CheckboxRequired(ErrorMessage = "You must confirm if you want to delete")]
    public bool DeleteAccount { get; set; } = false;

}
