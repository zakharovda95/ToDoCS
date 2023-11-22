using ToDoCS.Interfaces;

namespace ToDoCS.Services;

public class TestService : ITestService
{
    private readonly IConfiguration _configuration;
    public TestService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string Show()
    {
        return _configuration.GetConnectionString("db")!;
    }
}