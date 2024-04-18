using Infrastructure.Models;

namespace Silicon_AspNetMVC.ViewModels.Account
{
    public class SavedCoursesViewModel
    {
        public string Title { get; set; } = "Saved Items";

        public CoursesModel Course { get; set; } = new CoursesModel();
    }
}    