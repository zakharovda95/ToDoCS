using Microsoft.AspNetCore.Mvc;
using ToDoCS.Helpers;
using ToDoCS.Interfaces;
using ToDoCS.Models.System;
using ToDoCS.ViewModels;

namespace ToDoCS.Controllers;

public class RegistrationController : Controller
{
    [HttpGet]
    [Route("Auth/[controller]", Name = "RegisterIndex")]
    [Route("Auth/[controller]/[action]", Name = "RegisterIndexAction")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Produces("application/json")]
    [Route("/api/Auth/[controller]/[action]", Name = "RegisterAction")]
    public IActionResult Register(
        [FromBody] RegistrationViewModel model, 
        [FromServices] IRegistrationService registrationService,
        [FromServices] ILoginService loginService)
    {
        if (!ModelState.IsValid)
            return BadRequest(new CustomFailedResult
            {
                Success = false,
                Message = "Ошибки формы",
                Errors = ModelStateErrorsHelper.GetErrors(ModelState),
            });

        var registerResult = registrationService.Register(model.Name, model.Email, model.Password);

        if (!registerResult.Success)
            return BadRequest(registerResult);
        
        var res = loginService.Login(model.Name, model.Password);
        return Ok(res);
    }
}