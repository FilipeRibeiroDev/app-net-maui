using BraboDevApp.Models.Users;
using BraboDevApp.Models.Users.Response;

namespace BraboDevApp.Services.Users
{
    public interface IUserService
    {
        Task<User> Add(User user);

        Task<UserToken> Authenticate(UserAuth auth);
    }
}
