using AuthLearn.BLL.Base;
using AuthLearn.Securities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthLearn.BLL;

public class TokenService : ITokenService
{
    private readonly JwtConfiguration _jwt;

    public TokenService(JwtConfiguration jwt)
    {
        _jwt = jwt;
    }


    public string GenerateToken(string email, string roleName)
    {
        var credentials = new SigningCredentials(_jwt.GetSigningKey(), SecurityAlgorithms.HmacSha256);

        var claims = new[]{
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, roleName)
        };

        var token = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30), 
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


}
