using System.ComponentModel.DataAnnotations;

namespace Silicon_AspNetMVC.Models.Sections
{
    public class AccountDetailsAddressInfoModel
    {
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
}
