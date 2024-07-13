namespace BraboDevApp.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private const string AccessToken = "acess_token";
        private readonly string AccessTokenDefault = string.Empty;

        public string AuthAccessToken 
        { 
            get => Preferences.Get(AccessToken, AccessTokenDefault); 
            set => Preferences.Set(AccessToken, value); 
        }
    }
}
