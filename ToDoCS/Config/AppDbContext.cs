using Microsoft.EntityFrameworkCore;
using ToDoCS.Models.Entities;

namespace ToDoCS.Config;

public sealed class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    private DbSet<User> Users { get; init; } = null!;
    
    public AppDbContext (IConfiguration configuration)
    {
        Database.EnsureCreated();
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Db"));
    }
}