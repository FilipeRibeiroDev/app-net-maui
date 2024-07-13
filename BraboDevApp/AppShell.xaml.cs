using BraboDevApp.Views;

namespace BraboDevApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeRouting();
            InitializeComponent();
        }

        public static void InitializeRouting()
        {
            Routing.RegisterRoute("cadastro", typeof(CadastroView));
            Routing.RegisterRoute("home", typeof(HomeView));
            Routing.RegisterRoute("login", typeof(LoginView));
        }
    }
}
