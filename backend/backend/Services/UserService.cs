using Microsoft.EntityFrameworkCore;

using backend.Helpers;
using backend.Interfaces;
using backend.Models;
using backend.Models.DataTransferObjects;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteUser(long id)
        {
            User? user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                throw new AppException("User not found", StatusCodes.Status404NotFound);
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserDto?> GetUser(long id)
        {
            return await _context.Users.Select(user => new UserDto()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            }).SingleOrDefaultAsync(user => user.Id == id);
        }

        public async Task<List<UserDto>> GetUsers()
        {
            return await _context.Users
                .Select(user => new UserDto()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber
                })
                .OrderBy(user => user.Id)
                .ToListAsync();
        }

        public async Task<UserDto> PostUser(User user)
        {
            IsUsernameOrEmailTaken(user.Username, user.Email);

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            };
        }

        public async Task PutUser(User user)
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

        /// <summary>
        /// Method throws error if username or email is taken.
        /// </summary>
        /// <exception cref="AppException" />

        private void IsUsernameOrEmailTaken(string? username, string? email)
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

        private bool UserExists(long id)
        {
            return _context.Users.Any(user => user.Id == id);
        }
    }
}
