using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ToDoCS.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
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