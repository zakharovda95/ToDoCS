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
    
    public CustomResult Register(string name, string email, string password)
    {
        try
        {
            if (_dbService.IsEmailAlreadyExist(email))
                return new CustomResult { Success = false, Message = "Email уже используется" };

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
            };

            var res = _dbService.SaveUser(newUser);
            return !res ? new CustomResult { Success = false, Message = "Регистрация не удалась" } : 
                new CustomSuccessResult<User> { Success = true, Message = "Успешная регистрация", Data = newUser };
        }
        catch (Exception e)
        {
            return new CustomResult { Success = false, Message = e.Message };
        }
    }
}