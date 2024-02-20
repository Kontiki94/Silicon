using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels
{
    public class CourseIndexViewModel
    {
        public string? Title { get; set; }
        public CourseDetailsViewModel? Course { get; set; }
    }
}
