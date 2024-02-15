using AuthLearn.BLL.Base;
using AuthLearn.DAL.Contexts;
using AuthLearn.DAL.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace AuthLearn.BLL;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IEncryptService _encryptService;
    private readonly AuthContext _context;

    public AuthService(AuthContext context, ITokenService tokenService, IEncryptService encryptService)
    {
        _tokenService = tokenService;
        _context = context;
        _encryptService = encryptService;
    }

    public async Task<IResult> Login(UserAuthRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
        if(user is null)
        {
            return Results.NotFound();
        }
        
        var password = _encryptService.HashPassword(request.Password, user.Salt);
        if(user.Password.SequenceEqual(password))
        {
            return Results.BadRequest();
        }

        var role = await _context.Roles.FirstAsync(x => x.Id == user.RoleId);

        var token = _tokenService.GenerateToken(user.Email, role.Name.ToString());
        return Results.Ok(token);
    }

    public async Task<IResult> Register(UserAuthRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (user is not null)
        {
            return Results.Conflict();
        }
        var role = await _context.Roles.FirstAsync(x => x.Name == request.Role.ToString());
        var salt = _encryptService.GenerateSalt();
        user = new User
        {
            Email = request.Email,
            Salt = salt,
            Password = _encryptService.HashPassword(request.Password, salt),
            RoleId = role.Id
        };

        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();

        var token = _tokenService.GenerateToken(user.Email, role.Name.ToString());
        return Results.Ok(token);
    }
}
