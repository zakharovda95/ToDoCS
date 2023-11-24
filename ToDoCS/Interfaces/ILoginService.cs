using ToDoCS.Models.System;

namespace ToDoCS.Interfaces;

public interface ILoginService
{
    public ActionResult? Login(string name, string password);
    public ActionResult Logout();
}