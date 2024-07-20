using BraboDevApp.Services.Navigation;

namespace BraboDevApp.Views;

public partial class MainView : ContentPage
{
	private readonly INavigationService _navigationService;
	public MainView(INavigationService navigationService)
	{
        _navigationService = navigationService;

        InitializeComponent();
	}

    private void Logout_Clicked(object sender, EventArgs e)
    {
        _navigationService.NavigationAsync("home?Logout=true");
    }
}