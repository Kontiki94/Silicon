﻿using Silicon_AspNetMVC.Models.Sections;

namespace Silicon_AspNetMVC.ViewModels.Courses
{
    public class CoursesViewModel
    {
        public string Title { get; set; } = null!;
        public IEnumerable<CoursesModel> AllCourses { get; set; } = [];
        public CoursesModel OneCourse { get; set; } = new CoursesModel();
        public string? ErrorMessage { get; set; }
        
    }
}
