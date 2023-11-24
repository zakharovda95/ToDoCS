using ToDoCS.Models.Entities;

namespace ToDoCS.Interfaces;

public interface IDBService
{
    public bool IsEmailAlreadyExist(string email);
    public User? GetUser(string name, string password);
    public bool SaveUser(User user);
}