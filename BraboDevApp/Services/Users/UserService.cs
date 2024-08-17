using BraboDevApp.Data;
using BraboDevApp.Models.Users;
using BraboDevApp.Models.Users.Response;
using BraboDevApp.Services.RequestProvider;

namespace BraboDevApp.Services.Users
{
    public class UserService(IRequestProvider requestProvider) : SQLiteConnection<User>, IUserService
    {
        private readonly IRequestProvider _requestProvider = requestProvider; 
        public async Task<User> Add(User user)
        {
            #region Local Database
            user.Username = "filipe";
            await AddAsync(user);
            #endregion

            var uri = GlobalSettings.Instance.UserEndpoint + "/add";
            return await _requestProvider.PostAsync<User, User>(uri, user);
        }

        public async Task<UserToken> Authenticate(UserAuth auth)
        {
            #region Local Database
            var user = await GetAsync(x => x.Username.Equals(auth.Username));
            #endregion

            var uri = GlobalSettings.Instance.UserEndpoint + "/login";
            return await _requestProvider.PostAsync<UserToken, UserAuth>(uri, auth);
        }

        public async Task<UserResponse> List()
        {
            var uri = GlobalSettings.Instance.UserEndpoint;
            return await _requestProvider.GetAsync<UserResponse>(uri);
        }
    }
}
