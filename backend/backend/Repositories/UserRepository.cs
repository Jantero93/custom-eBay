using Microsoft.EntityFrameworkCore;

using backend.Helpers;
using backend.Interfaces.Repositories;
using backend.Models;

namespace backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            user.Created = System.DateTime.UtcNow.ToString("o");
            _context.Users.Add(user);

            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method throws error if username or email is taken.
        /// </summary>
        /// <exception cref="AppException" />
        public void EmailOrUsernameAvailable(string? email, string? username)
        {
            if (_context.Users.Any(user => user.Username == username))
            {
                throw new AppException("Username is already taken", StatusCodes.Status409Conflict);
            }

            if (_context.Users.Any(user => user.Email == email))
            {
                throw new AppException("Email is already taken", StatusCodes.Status409Conflict);
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users
                .OrderBy(u => u.Id)
                .ToListAsync();
        }

        public async Task<User> GetUser(long id)
        {
            User? user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                throw new AppException("No user found", StatusCodes.Status404NotFound);
            }

            return user;
        }

        public async Task<User> GetUserByUsername(string? username)
        {
            User? user = await _context.Users
                .SingleOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                throw new AppException("No user by username", StatusCodes.Status404NotFound);
            }

            return user;
        }

        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    throw new AppException("User not found", StatusCodes.Status404NotFound);
                }
                else
                {
                    throw;
                }
            }
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(user => user.Id == id);
        }
    }
}
