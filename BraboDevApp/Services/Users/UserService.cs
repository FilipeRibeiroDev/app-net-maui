using BraboDevApp.Models.Users;
using BraboDevApp.Services.RequestProvider;

namespace BraboDevApp.Services.Users
{
    public class UserService(IRequestProvider requestProvider) : IUserService
    {
        private readonly IRequestProvider _requestProvider = requestProvider; 
        public async Task<User> Add(User user)
        {
            var uri = GlobalSettings.Instance.UserEndpoint + "/add";
            return await _requestProvider.PostAsync(uri, user);
        }
    }
}
