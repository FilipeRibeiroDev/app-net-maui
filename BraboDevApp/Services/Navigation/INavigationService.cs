namespace BraboDevApp.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigationAsync(string route);
    }
}
