using Silicon_AspNetMVC.Models.Components;
using Silicon_AspNetMVC.Models.Sections;
using static System.Net.Mime.MediaTypeNames;

namespace Silicon_AspNetMVC.ViewModels.Home;

public class DownloadViewModel
{
    public string? Id { get; set; } 
    public ImageViewModel Image { get; set; } = new();
    public SectionTitleModel SectionTitle { get; set; } = new();

    public List<DownloadAppModel> DownloadBox { get; set; } = new(); 
   
    public DownloadViewModel() 
    {
        Id = "download";
        Image.ImageUrl = "/images/iphone.svg";
        Image.AltText = "image of a mobile phone";
        SectionTitle.Title = "Download Our App for Any Devices:";
     

        DownloadBox =
        [
            new DownloadAppModel() { StoreName = "App Store", Title = "Editor's Choice", Rating = "rating 4.7, 187K+ reviews", LinkUrl= "https://www.apple.com/se/app-store/", Image = { ImageUrl = "/images/appstore.svg", AltText ="Go to appstore" } },            
            new DownloadAppModel() { StoreName = "Google Play", Title = "App of the Day", Rating = "rating 4.8, 30K+ reviews", LinkUrl= "https://play.google.com/", Image = { ImageUrl = "/images/googleplay.svg", AltText = "Go to google play" } }           
        ];        

    }


}
