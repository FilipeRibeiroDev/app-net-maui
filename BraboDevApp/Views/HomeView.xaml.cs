using BraboDevApp.Services.Settings;

namespace BraboDevApp.Views;

[QueryProperty(nameof(Logout), "Logout")]
public partial class HomeView : ContentPage
{
    public bool Logout { get; set; }

    private readonly ISettingsService _settingsService;
    public HomeView(ISettingsService settingsService)
	{
        _settingsService = settingsService;

        InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (Logout)
        {
            _settingsService.AuthAccessToken = string.Empty;
        }
    }

    private async void Registrar_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("cadastro?route=home");
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("login");
    }

}