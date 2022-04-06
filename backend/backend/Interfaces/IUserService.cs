using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Interfaces
{
    public interface IUserService
    {
        Task<bool> DeleteUser(long id);
        Task<User?> GetUser(long id);
        Task<List<User>> GetUsers();
        bool IsUsernameTaken(string username);
        Task<User> PostUser(User user);
        Task<bool> PutUser(User user);
    }
}
