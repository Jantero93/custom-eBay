using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using backend.Helpers;
using backend.Interfaces.Repositories;
using backend.Interfaces.Services;
using backend.Models;
using backend.Models.DataTransferObjects;
using backend.Models.ViewModels;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly ILocationRepository _locationRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IConfiguration config,
            IUserRepository userRepository,
            ILocationRepository locationRepository)
        {
            _config = config;
            _locationRepository = locationRepository;
            _userRepository = userRepository;
        }

        public async Task DeleteUser(long id)
        {
            User user = await _userRepository.GetUser(id);

            await _userRepository.DeleteUser(user);
        }

        public async Task<UserDto> GetUser(long id)
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

        public async Task<UserDto> GetUser(string username)
        {
            User user = await _userRepository.GetUserByUsername(username);

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

        public async Task<string> Login(UserViewModel user)
        {

            User DbUser = await _userRepository.GetUserByUsername(user.Username);

            bool passwordCorrect = BCrypt.Net.BCrypt.Verify(user.Password, DbUser.Password);

            if (!passwordCorrect)
            {
                throw new AppException("Incorrect password", StatusCodes.Status403Forbidden);
            }

            return GenerateToken(DbUser);
        }

        public async Task<UserDto> PostUser(UserViewModel user)
        {
            _userRepository.EmailOrUsernameAvailable(user.Email, user.Username);

            string salt = BCrypt.Net.BCrypt.GenerateSalt(10);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);

            User savedUser = await _userRepository.AddUser(new User()
            {
                Username = user.Username,
                Password = hashedPassword,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Location = await _locationRepository.GetLocationByCity(user.City),
                Role = UserRole.Normal,
                PhoneNumber = user.PhoneNumber,
            });

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

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["token_secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
