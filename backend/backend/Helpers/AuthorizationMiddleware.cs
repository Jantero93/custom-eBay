using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using backend.Interfaces.Repositories;

namespace backend.Helpers
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
                context.Items["User"] = await _userRepository.GetUser(userId.Value);
            }

            await _next(context);
        }

        public long? ValidateToken(string? token)
        {
            if (token == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["token_secret"]);

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
