using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UserApi.Models;

namespace UserApi.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim("id", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.BornDate.ToString()),
            new Claim("loginTimeStamp", DateTime.UtcNow.ToString())
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("oudsoudncmUIUUHPUI14257fdvvdsvvdsvdf778747578f7bf7e87s76"));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
        (
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}