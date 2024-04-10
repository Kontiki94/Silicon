using Infrastructure.Entities.HomeEntities;

namespace Silicon_AspNetMVC.ViewModels.Home
{
    public class HomeLightAndDarkViewModel
    {
        public string TitleWhite { get; set; } = null!;
        public string TitleBlack { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string ImageAlt { get; set; } = null!;
        public string IconUrl { get; set; } = null!;
        public string IconAlt { get; set; } = null!;

        //public HomeLightAndDarkViewModel(DarkLightEntity entity)
        //{
        //    TitleWhite = entity.TitleWhite;
        //    TitleBlack = entity.TitleBlack;
        //    ImageUrl = entity.ImageUrl;
        //    ImageAlt = entity.ImageAlt;
        //    IconUrl = entity.IconUrl;
        //    IconAlt = entity.IconAlt;
        //}

        public HomeLightAndDarkViewModel()
        {
            TitleWhite = "Switch Between";
            TitleBlack = "Light and Dark";
            ImageUrl = "images/macbook_test.png";
            ImageAlt = "Laptop";
            IconUrl = "images/arrows_laptop.png";
            IconAlt = "Macbook";
        }
    }
}
