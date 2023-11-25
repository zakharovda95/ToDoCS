using ToDoCS.Models.System;

namespace ToDoCS.Interfaces;

public interface ILoginService
{
    public CustomResult? Login(string name, string password);
    public CustomResult Logout();
}