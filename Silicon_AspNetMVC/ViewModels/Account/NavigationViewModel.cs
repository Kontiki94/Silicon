namespace Silicon_AspNetMVC.ViewModels.Account;

public class NavigationViewModel
{
    public string ActiveAction { get; set; }
    public NavigationViewModel(string activeAction = "Details")
    {
        ActiveAction = activeAction;
    }
}
