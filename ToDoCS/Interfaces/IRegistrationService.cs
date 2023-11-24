using ToDoCS.Models.System;

namespace ToDoCS.Interfaces;

public interface IRegistrationService
{
    public ActionResult Register(string name, string email, string password);
}