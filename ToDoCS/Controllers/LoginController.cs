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
    public IActionResult Login(LoginViewModel model, [FromServices] ILoginService loginService)
    {
        if (ModelState.IsValid && model is { Name: not null, Password: not null })
        {
            var token = loginService.Login(model.Name, model.Password);
            if(token is null) return View("Index", model);
            return Ok(new { status = "Success", token = token });
        }
        
        return View("Index", model);
    }
}