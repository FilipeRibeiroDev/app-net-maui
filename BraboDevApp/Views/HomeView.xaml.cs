namespace BraboDevApp.Views;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
	}

    private async void Registrar_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("cadastro?route=home");
    }
}