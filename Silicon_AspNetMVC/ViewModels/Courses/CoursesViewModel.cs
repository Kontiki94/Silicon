using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels.Courses
{
    public class CoursesViewModel
    {
        public string Title { get; set; } = null!;
        public IEnumerable<CoursesModel> AllCourses { get; set; } = [];
        public OneCourseModel OneCourse { get; set; } = new OneCourseModel();
    }
}
