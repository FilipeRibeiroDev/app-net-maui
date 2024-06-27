using BraboDevApp.Models.Users;

namespace BraboDevApp.Services.Users
{
    public interface IUserService
    {
        Task<User> Add(User user);  
    }
}
