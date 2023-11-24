using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using ToDoCS.Config;
using ToDoCS.Interfaces;
using ToDoCS.Models.System;

namespace ToDoCS.Services;

public class LoginService : ILoginService
{
    private readonly IDBService _dbService;
    public LoginService(IDBService dbService)
    {
        _dbService = dbService;
    }
    
    public ActionResult Login(string name, string password)
    {
        var user = _dbService.GetUser(name, password);

        if (user is null) return new ActionResult { Success = false, Message = "Пользователь не найден" };
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, name) };
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
        );

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);
        return new ActionResult { Success = false, Message = token };
    }

    public ActionResult Logout()
    {
        throw new NotImplementedException();
    }
}