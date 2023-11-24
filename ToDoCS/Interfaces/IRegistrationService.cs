using ToDoCS.Models.Entities;

namespace ToDoCS.Interfaces;

public interface IRegistrationService
{
    public User Register(string name, string email, string password);
}