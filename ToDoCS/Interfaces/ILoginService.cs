namespace ToDoCS.Interfaces;

public interface ILoginService
{
    public string? Login(string name, string password);
    public void Logout();
}