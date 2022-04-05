using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using backend.Interfaces;
using backend.Models;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUser(long id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
