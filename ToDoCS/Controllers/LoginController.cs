using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToDoCS.Config;
using ToDoCS.Interfaces;
using ToDoCS.ViewModels;

namespace ToDoCS.Controllers;

public class LoginController: Controller
{
    [HttpGet]
    [Route("Auth/[controller]", Name = "LoginIndex")]
    [Route("Auth/[controller]/[action]", Name = "LoginIndexAction")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("/api/Auth/[controller]/[action]", Name = "LoginAction")]
    public IActionResult Login(LoginViewModel model, [FromServices] IDBService dbService)
    {
        if (ModelState.IsValid && model is { Name: not null, Password: not null })
        {
            var user = dbService.GetUser(model.Name, model.Password);

            if (user is null) return View("Index", model);
            
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, model.Name!) };
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new { status = "Success", token = token });
        }
        
        return View("Index", model);
    }
}