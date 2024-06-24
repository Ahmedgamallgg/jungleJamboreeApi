using Core.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.TokenService.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.TokenService.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _Config;
        private readonly SymmetricSecurityKey _Key;
        public TokenService(IConfiguration config)
        {
            _Config = config;
            _Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config["Token:Key"]));
            
            
        }


        public string CreateToken(Users user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, $"{user.FName} {user.Lname}")
            };

            var creds = new SigningCredentials(_Key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _Config["Token:Issuer"],
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = creds,
                NotBefore = DateTime.UtcNow,

            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
