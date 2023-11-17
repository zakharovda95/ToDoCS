using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoCS.Helpers.HtmlHelpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

var app = builder.Build();
app.MapControllers();
app.UseStaticFiles();

app.Run();