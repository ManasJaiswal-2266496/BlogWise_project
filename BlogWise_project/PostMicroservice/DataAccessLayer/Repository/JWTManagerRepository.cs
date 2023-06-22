using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlogWise_project.PostMicroservice.DataAccessLayer.Repository;
using Microsoft.IdentityModel.Tokens;
using UserMicroservice.DataAccessLayer.Models;

namespace PostMicroservice.DataAccessLayer.Repository
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly IConfiguration _configuration;
        private readonly Dictionary<string, User> _usersRecords;

        public JWTManagerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _usersRecords = new Dictionary<string, User>
            {
                // Add your dummy user records here
                { "username1", new User { Username = "username1", Password = "password1" } },
                { "username2", new User { Username = "username2", Password = "password2" } }
            };
        }

        public string Authenticate(User user)
        {
            // Check if the user exists in the dictionary
            if (!_usersRecords.ContainsKey(user.Username) || _usersRecords[user.Username].Password != user.Password)
            {
                return null;
            }

            // Create claims for the user
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            // Generate a JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JWT:ExpirationMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
