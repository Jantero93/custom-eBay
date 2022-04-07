using backend.Models;
using backend.Models.DataTransferObjects;

namespace backend.Interfaces
{
    public interface IUserService
    {
        Task DeleteUser(long id);
        Task<UserDto?> GetUser(long id);
        Task<List<UserDto>> GetUsers();
        Task<UserDto> PostUser(User user);
        Task PutUser(User user);
    }
}
