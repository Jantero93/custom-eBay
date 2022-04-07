using backend.Models;

namespace backend.Interfaces
{
    public interface IUserService
    {
        Task DeleteUser(long id);
        Task<User?> GetUser(long id);
        Task<List<User>> GetUsers();
        Task<User> PostUser(User user);
        Task PutUser(User user);
    }
}
