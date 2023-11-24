using Microsoft.AspNetCore.Mvc;
using ToDoCS.Interfaces;
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
    [Route("/api/Auth/[controller]/[action]", Name = "RegisterAction")]
    public IActionResult Register(RegistrationViewModel model, [FromServices] IRegistrationService registrationService)
    {
        if (!ModelState.IsValid)
            return View("Index", model);

        var registerResult = registrationService.Register(model.Name, model.Email, model.Password);

        if (registerResult.Success)
        {
            return Ok(new { status = "Success", message = "Регистрация успешна" });
        }
        
        return View("Index", model);
    }
}