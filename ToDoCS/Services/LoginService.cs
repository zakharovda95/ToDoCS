using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using ToDoCS.Config;
using ToDoCS.Interfaces;

namespace ToDoCS.Services;

public class LoginService : ILoginService
{
    private readonly IDBService _dbService;
    public LoginService(IDBService dbService)
    {
        _dbService = dbService;
    }
    
    public string? Login(string name, string password)
    {
        var user = _dbService.GetUser(name, password);

        if (user is null) return null;
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, name) };
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public void Logout()
    {
        throw new NotImplementedException();
    }
}