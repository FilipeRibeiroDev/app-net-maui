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
            DisplayAlert("Login de Usuário", "Usuário ou senha inválidos", "Ok!");
        else
        {
            _settingsService.AuthAccessToken = response.Token;

            DisplayAlert("Login de Usuário", string.Format("Usuário {0} logado com sucesso", response.FirstName), "Ok!");

            await Shell.Current.GoToAsync("//Main/Main");
        }
    }
}