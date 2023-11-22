using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDoCS.Config;
using ToDoCS.Interfaces;
using ToDoCS.Models.Entities;
using ToDoCS.Services;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration.GetConnectionString("Db");
//builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

//builder.Services.AddTransient<IDBService, DBService>();
builder.Services.AddSingleton<ITestService, TestService>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = AuthOptions.ISSUER,
        ValidateAudience = true,
        ValidAudience = AuthOptions.AUDIENCE,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
        
    };
});
builder.Services.AddAuthorization();

var app = builder.Build();

app.MapControllers();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.Run();