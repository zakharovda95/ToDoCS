using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ToDoCS.Config;

public static class AuthOptions
{
    public static string ISSUER = "todo-cs-issuer";
    public static string AUDIENCE = "todo-cs-audience";
    private static string KEY = "todo-cs-secretkey-123";
    
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}