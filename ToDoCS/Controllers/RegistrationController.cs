using Microsoft.AspNetCore.Mvc;
using ToDoCS.Config;
using ToDoCS.Interfaces;
using ToDoCS.Models.Entities;
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
    public IActionResult Register(RegistrationViewModel model, [FromServices] IDBService dbService)
    {
        if (!ModelState.IsValid)
            return View("Index", model);

        if (dbService.IsEmailAlreadyExist(model.Email))
        {
            return View("Index", model);
        }

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Email = model.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
        };

        var isUserSaved = dbService.SaveUser(newUser);

        if (isUserSaved)
        {
            return Ok(new { status = "Success", message = "Регистрация успешна" });
        }
        
        return View("Index", model);
    }
}