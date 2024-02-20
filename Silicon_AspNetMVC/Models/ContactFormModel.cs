﻿using System.ComponentModel.DataAnnotations;

namespace Silicon_AspNetMVC.Models;

public class ContactFormModel
{
    [Display(Name = "Full name", Prompt = "Enter your full name", Order = 0)]
    [Required(ErrorMessage = "Name is required")]
    public string FullName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]                                                            
    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 1)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Service (Optional)", Prompt = "Choose the service you are interested in", Order = 2)]
    [Required(ErrorMessage = "You need to select a service")]
    public string Service { get; set; } = null!;

    [Display(Name = "Message", Prompt = "Enter your message here", Order = 3)]
    [StringLength(500, MinimumLength = 5, ErrorMessage = "Your message must be between 5 and 500 characters")]
    public string Message { get; set; } = null!;

}
