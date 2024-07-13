using BraboDevApp.Models.Users;
using BraboDevApp.Models.Users.Response;
using BraboDevApp.Services.RequestProvider;

namespace BraboDevApp.Services.Users
{
    public class UserService(IRequestProvider requestProvider) : IUserService
    {
        private readonly IRequestProvider _requestProvider = requestProvider; 
        public async Task<User> Add(User user)
        {
            var uri = GlobalSettings.Instance.UserEndpoint + "/add";
            return await _requestProvider.PostAsync<User, User>(uri, user);
        }

        public async Task<UserToken> Authenticate(UserAuth auth)
        {
            var uri = GlobalSettings.Instance.UserEndpoint + "/login";
            return await _requestProvider.PostAsync<UserToken, UserAuth>(uri, auth);
        }
    }
}
