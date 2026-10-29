using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotnetApi.configuration;
using DotnetApi.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
namespace DotnetApi.Services;

    public class JwtService : IJwtService
    {
        private readonly JwtSettings _settings;
        public JwtService(IOptions<JwtSettings> options)
        {
            _settings = options.Value;

        }
        public string GenerateToken(int userId, string username,string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, username),
                new Claim(ClaimTypes.Role,role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_settings.Key)
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    _settings.ExpiresMinutes
                ),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
