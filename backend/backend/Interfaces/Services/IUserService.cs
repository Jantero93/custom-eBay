using backend.Models;
using backend.Models.DataTransferObjects;
using backend.Models.ViewModels;

namespace backend.Interfaces.Services
{
    public interface IUserService
    {
        Task DeleteUser(long id);
        Task<UserDto> GetUser(long id);
        Task<List<UserDto>> GetUsers();
        Task<string> Login(UserViewModel user);
        Task<UserDto> PostUser(UserViewModel user);
        Task PutUser(User user);
    }
}