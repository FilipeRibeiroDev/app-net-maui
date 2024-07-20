using BraboDevApp.Services.Navigation;
using BraboDevApp.Views;

namespace BraboDevApp
{
    public partial class AppShell : Shell
    {
        private readonly INavigationService _navigationService;
        public AppShell(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeRouting();
            InitializeComponent();
        }

        protected override async void OnHandlerChanged()
        {
            base.OnHandlerChanged();

            if(Handler is not null)
            {
                await _navigationService.InitializeAsync();
            }
        }

        public static void InitializeRouting()
        {
            Routing.RegisterRoute("cadastro", typeof(CadastroView));
            Routing.RegisterRoute("home", typeof(HomeView));
            Routing.RegisterRoute("login", typeof(LoginView));
        }
    }
}
