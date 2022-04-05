using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly DataContext _context;

        public LoggerService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public void LogMe(string message)
        {
            System.Diagnostics.Debug.WriteLine(message + "  SADASDASDASDASDDASDAS");
        }
    }
}
