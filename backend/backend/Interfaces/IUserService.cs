using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Interfaces
{
    public interface IUserService
    {
        Task<ActionResult<IEnumerable<User>>> GetUsers();
        Task<User?> GetUser(long id);
    }
}
