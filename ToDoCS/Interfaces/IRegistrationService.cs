using ToDoCS.Models.System;

namespace ToDoCS.Interfaces;

public interface IRegistrationService
{
    public CustomResult Register(string name, string email, string password);
}