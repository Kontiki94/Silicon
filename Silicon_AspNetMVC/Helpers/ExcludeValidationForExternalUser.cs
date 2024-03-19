using Silicon_AspNetMVC.ViewModels.Account;
using System.ComponentModel.DataAnnotations;

namespace Silicon_AspNetMVC.Helpers;

public class ExcludeValidationForExternalUser : ValidationAttribute
{

    //protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    //{
    //    if (validationContext == null)
    //    {
    //        return new ValidationResult("Validation context is null.");
    //    }

    //    if (validationContext.ObjectInstance == null)
    //    {
    //        return new ValidationResult("Object instance is null.");
    //    }

    //    var model = (AccountDetailsBasicInfoViewModel)validationContext.ObjectInstance;

    //    if (model.IsExternalAccount)
    //    {
    //        if (validationContext.MemberName == "FirstName" ||
    //            validationContext.MemberName == "LastName" ||
    //            validationContext.MemberName == "Email")
    //        {
    //            return ValidationResult.Success;
    //        }
    //    }

    //    return base.IsValid(value, validationContext);
    //}
}
