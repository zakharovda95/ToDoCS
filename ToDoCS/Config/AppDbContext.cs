using Microsoft.EntityFrameworkCore;
using ToDoCS.Models.Entities;

namespace ToDoCS.Config;

public sealed class AppDbContext : DbContext
{
    public DbSet<User> Users { get; init; } = null!;

    public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}