using BraboDevApp.Models.Users;
using BraboDevApp.Services.Users;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BraboDevApp.Views;

public partial class UsuariosView : ContentPage, INotifyPropertyChanged
{
	private ObservableCollection<User> _users { get; set; }
	public ObservableCollection<User> Users 
    { 
        get => _users;
        set
        {
            _users = value;
            OnPropertyChanged();
        }
    }

    public IUserService _userService { get; set; }
    public event PropertyChangedEventHandler PropertyChanged;
    public UsuariosView(IUserService userService)
	{
        _userService = userService;
        InitializeComponent();
        BindingContext = this;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var response = await _userService.List();
        Users = new ObservableCollection<User>(response.Users);
    }

    protected void OnPropertyChanged([CallerMemberName] string propetyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propetyName));
    }
}