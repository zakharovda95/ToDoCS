using Microsoft.AspNetCore.Mvc;
using ToDoCS.Helpers;
using ToDoCS.Interfaces;
using ToDoCS.Models.System;
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
    public IActionResult Login([FromBody] LoginViewModel model, [FromServices] ILoginService loginService)
    {
        if (!ModelState.IsValid)
            return BadRequest(new CustomFailedResult
            {
                Success = false,
                Message = "Ошибки формы",
                Errors = ModelStateErrorsHelper.GetErrors(ModelState)
            });

        if (model is { Name: not null, Password: not null})
        {
            var loginResult = loginService.Login(model.Name, model.Password);
            if (loginResult is not null && loginResult.Success) return Ok(loginResult);
            return NotFound(loginResult);
        }

        return BadRequest(new CustomResult { Success = false, Message = "Вход в систему не удался" });
    }
}