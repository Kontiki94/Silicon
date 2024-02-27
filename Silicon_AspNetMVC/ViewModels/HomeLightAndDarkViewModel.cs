﻿namespace Silicon_AspNetMVC.ViewModels
{
    public class HomeLightAndDarkViewModel
    {
        public string TitleWhite { get; set; } = null!;
        public string TitleBlack { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string ImageAlt { get; set; } = null!;
        public string IconUrl { get; set; } = null!;
        public string IconAlt { get; set; } = null!;

        public HomeLightAndDarkViewModel() 
        {
            TitleWhite = "Switch Between";
            TitleBlack = "Lignt and Dark";
            ImageUrl = "images/macbook_test.png";
            ImageAlt = "Laptop";
            IconUrl = "images/arrows_laptop.png";
            IconAlt = "Macbook";
        }
    }
}
