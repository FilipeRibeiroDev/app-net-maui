using BraboDevApp.Models.Users;
using BraboDevApp.Services.Settings;
using BraboDevApp.Services.Users;

namespace BraboDevApp.Views;

public partial class LoginView : ContentPage
{
	private readonly IUserService _userService;
	private readonly ISettingsService _settingsService;
	public LoginView(ISettingsService settingsService, IUserService userService)
	{
        _userService = userService;
        _settingsService = settingsService;
        InitializeComponent();
	}

    private async void Login_Clicked(object sender, EventArgs e)
    {
        var auth = new UserAuth()
        {
            Username = Username.Text,
            Password = Password.Text,
            ExpiresInMins = 30
        };

        var response = await _userService.Authenticate(auth);

        if(response == null)
            DisplayAlert("Login de Usu�rio", "Usu�rio ou senha inv�lidos", "Ok!");
        else
        {
            _settingsService.AuthAccessToken = response.Token;

            DisplayAlert("Login de Usu�rio", string.Format("Usu�rio {0} logado com sucesso", response.FirstName), "Ok!");

            await Shell.Current.GoToAsync("//Main/Main");
        }
    }
}