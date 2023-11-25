using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using ToDoCS.Config;
using ToDoCS.Interfaces;
using ToDoCS.Models;
using ToDoCS.Models.Entities;
using ToDoCS.Models.System;

namespace ToDoCS.Services;

public class LoginService : ILoginService
{
    private readonly IDBService _dbService;
    public LoginService(IDBService dbService)
    {
        _dbService = dbService;
    }
    
    public CustomResult Login(string name, string password)
    {
        try
        {
            var user = _dbService.GetUser(name, password);

            if (user is null) 
                return new CustomResult { Success = false, Message = "Пользователь не найден" };
            
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, name) };
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(
                    AuthOptions.GetSymmetricSecurityKey(), 
                    SecurityAlgorithms.HmacSha256)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new CustomSuccessResult<PublicUser>
            {
                Success = true, 
                Message = "Успешно!", 
                Data = new PublicUser
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Token = token
                }
            };
        }
        catch (Exception e)
        {
            return new CustomResult { Success = false, Message = e.Message };
        }
    }

    public CustomResult Logout()
    {
        throw new NotImplementedException();
    }
}