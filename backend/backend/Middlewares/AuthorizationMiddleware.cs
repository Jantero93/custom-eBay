using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using backend.Helpers;
using backend.Interfaces.Repositories;

namespace backend.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly IConfiguration _config;
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next,
            IConfiguration config)
        {
            _config = config;
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserRepository _userRepository)
        {
            string? token = context.Request.Cookies["X-Access-Token"];

            long? userId = ValidateToken(token);

            if (userId != null)
            {
                try
                {
                    context.Items["User"] = await _userRepository.GetUser(userId.Value);
                }
                catch
                {
                    // No need to handle expection if user is not found
                }
            }

            await _next(context);
        }

        public long? ValidateToken(string? token)
        {
            if (token == null)
            {
                return null;
            }

            string? secret = Environment.GetEnvironmentVariable("token_secret");
            if (secret == null) throw new AppException("Token secret env not found", StatusCodes.Status500InternalServerError);

            var key = Encoding.ASCII.GetBytes(secret);

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // Set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = long.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                return userId;
            }
            catch
            {
                return null;
            }
        }
    }
}
