using ToDoCS.Config;
using ToDoCS.Interfaces;
using ToDoCS.Models.Entities;

namespace ToDoCS.Services;

public class DBService : IDBService
{
    private readonly AppDbContext _dbContext;
    
    public DBService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public bool IsEmailAlreadyExist(string email)
    {
        return _dbContext.Users.Any(user => user.Email == email);
    }

    public User? GetUser(string name, string password)
    {
        var user = _dbContext.Users.FirstOrDefault(user => user.Name == name);
        if (user is not null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            return user;

        return null;

    }

    public bool SaveUser(User user)
    {
        _dbContext.Users.Add(user);
        var res =_dbContext.SaveChanges();
        return res > 0;
    }
}
