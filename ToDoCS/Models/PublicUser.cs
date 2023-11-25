using ToDoCS.Models.Entities;

namespace ToDoCS.Models;

public record PublicUser : User
{
    public string? Token { get; init; }
};