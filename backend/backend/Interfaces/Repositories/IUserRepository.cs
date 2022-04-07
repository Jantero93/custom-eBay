using backend.Models;

namespace backend.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task DeleteUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(long id);
        Task<User> GetUserByUsername(string? username);
        Task UpdateUser(User user);
        void EmailOrUsernameAvailable(string? email, string? username);
    }
}
