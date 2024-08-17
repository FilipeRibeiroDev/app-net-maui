using BraboDevApp.Services.Navigation;
using BraboDevApp.Services.RequestProvider;
using BraboDevApp.Services.Settings;
using BraboDevApp.Services.Users;
using BraboDevApp.Views;
using Microsoft.Extensions.Logging;

namespace BraboDevApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterAppService()
                .RegisterViews();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterAppService(this MauiAppBuilder app)
        {
            app.Services.AddSingleton<IRequestProvider, RequestProvider>();
            app.Services.AddSingleton<INavigationService, NavigationService>();
            app.Services.AddSingleton<ISettingsService, SettingsService>();
            app.Services.AddSingleton<IUserService, UserService>();
            return app;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder app)
        {
            app.Services.AddTransient<CadastroView>();
            app.Services.AddTransient<LoginView>();
            app.Services.AddTransient<MainView>();
            app.Services.AddTransient<HomeView>();
            app.Services.AddTransient<UsuariosView>();
            return app;
        }
    }
}
