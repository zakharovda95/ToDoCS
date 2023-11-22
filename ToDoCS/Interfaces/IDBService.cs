using ToDoCS.Models.Entities;

namespace ToDoCS.Interfaces;

public interface IDBService
{
    public bool IsEmailAlreadyExist(string email);
    public bool SaveUser(User user);
}