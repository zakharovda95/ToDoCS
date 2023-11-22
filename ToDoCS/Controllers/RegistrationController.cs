using Microsoft.AspNetCore.Mvc;
using ToDoCS.Config;
using ToDoCS.Interfaces;
using ToDoCS.Models.Entities;
using ToDoCS.ViewModels;

namespace ToDoCS.Controllers;
public class RegistrationController: Controller
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
    public IActionResult Register([FromBody] RegistrationViewModel model, AppDbContext dbContext)
    {
        
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        if (dbContext.Users.Any(user => user.Email == model.Email)) 
            return BadRequest(new { success = false, message = "Email уже используется" });

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Email = model.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
        };

        //var isUserSaved = dbService.SaveUser(newUser);
        
        dbContext.Users.Add(newUser);
        var res = dbContext.SaveChanges();
        Console.WriteLine(res);

        return Json(new { result = true, message = "Регистрация успешна" });
    }
}