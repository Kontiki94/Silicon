﻿using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels;

public class SignInViewModel
{
    public string Title { get; set; } = "Sign in";
    public SignInModel Form { get; set; } = new SignInModel();
}