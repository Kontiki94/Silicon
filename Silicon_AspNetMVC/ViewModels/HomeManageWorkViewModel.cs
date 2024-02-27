namespace Silicon_AspNetMVC.ViewModels
{
    public class HomeManageWorkViewModel
    {
        public List<string>? Features { get; set; }
        public string ButtonText { get; set; }
        public string ButtonIcon { get; set; }

        public HomeManageWorkViewModel() 
        {
            Features = new List<string>()
            {
                "Powerful project management",
                "Transparent work management",
                "Manage work & focus on the most important tasks",
                "Track your progress with interactive charts",
                "Easiest way to track time spent on tasks"
            };

            ButtonText = "Learn more";
            ButtonIcon = "fa-solid fa-arrow-right";
        }
    }
}
