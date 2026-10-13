using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace JwtDemo.Services; 


public class TokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateAccessToken(int userId, string username)
    {
        return GenerateToken(userId, username,
            _configuration["Jwt:AccessSecret"]!,
            int.Parse(_configuration["Jwt:AccessExpiresMinutes"]!));
    }

    public string GenerateRefreshToken(int userId, string username)
    {
        return GenerateToken(userId, username,
            _configuration["Jwt:RefreshSecret"]!,
            int.Parse(_configuration["Jwt:RefreshExpiresDays"]!) * 24 * 60);
    }

    private string GenerateToken(int userId, string username, string secret, int expiresMinutes)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, username)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiresMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}