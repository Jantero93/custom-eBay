using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Interfaces
{
    public interface ILoggerService
    {
        void LogMe(string message);
        Task<ActionResult<IEnumerable<User>>> GetUsers();
    }
}
