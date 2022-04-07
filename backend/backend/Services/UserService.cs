using backend.Interfaces.Repositories;
using backend.Interfaces.Services;
using backend.Models;
using backend.Models.DataTransferObjects;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task DeleteUser(long id)
        {
            User user = await _userRepository.GetUser(id);

            await _userRepository.DeleteUser(user);
        }

        public async Task<UserDto?> GetUser(long id)
        {
            User user = await _userRepository.GetUser(id);

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

        public async Task<List<UserDto>> GetUsers()
        {
            List<User> users = await _userRepository.GetAllUsers();

            return users.ConvertAll(u => new UserDto()
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                PhoneNumber = u.PhoneNumber
            });
        }

        public async Task<UserDto> PostUser(User user)
        {
            _userRepository.EmailOrUsernameAvailable(user.Email, user.Username);

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            User savedUser = await _userRepository.AddUser(user);

            return new UserDto()
            {
                Id = savedUser.Id,
                Username = savedUser.Username,
                Email = savedUser.Email,
                FirstName = savedUser.FirstName,
                LastName = savedUser.LastName,
                PhoneNumber = savedUser.PhoneNumber
            };
        }

        public async Task PutUser(User user)
        {
            await _userRepository.UpdateUser(user);
        }
    }
}
