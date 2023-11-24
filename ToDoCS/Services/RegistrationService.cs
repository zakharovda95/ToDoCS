using ToDoCS.Interfaces;
using ToDoCS.Models.Entities;
using ToDoCS.Models.System;

namespace ToDoCS.Services;

public class RegistrationService : IRegistrationService
{
    private readonly IDBService _dbService;
    public RegistrationService(IDBService dbService)
    {
        _dbService = dbService;
    }
    
    public ActionResult Register(string name, string email, string password)
    {
        if (_dbService.IsEmailAlreadyExist(email))
            return new ActionResult { Success = false, Message = "Email уже используется" };

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email,
            Password = BCrypt.Net.BCrypt.HashPassword(password),
        };

        var res = _dbService.SaveUser(newUser);
        if (!res) return new ActionResult { Success = false, Message = "Регистрация не удалась" };
        return new ActionResult { Success = false, Message = "Успешная регистрация" };
    }
}