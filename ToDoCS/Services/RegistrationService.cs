using ToDoCS.Interfaces;
using ToDoCS.Models.Entities;

namespace ToDoCS.Services;

public class RegistrationService : IRegistrationService
{
    private readonly IDBService _dbService;
    public RegistrationService(IDBService dbService)
    {
        _dbService = dbService;
    }
    
    public User Register(string name, string email, string password)
    {
        throw new NotImplementedException();
    }
}