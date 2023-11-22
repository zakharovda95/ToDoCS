using Microsoft.AspNetCore.Mvc;
using ToDoCS.Config;
using ToDoCS.Interfaces;
using ToDoCS.ViewModels;

namespace ToDoCS.Controllers;

public class LoginController: Controller
{
    [HttpGet]
    [Route("Auth/[controller]", Name = "LoginIndex")]
    [Route("Auth/[controller]/[action]", Name = "LoginIndexAction")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("/api/Auth/[controller]/[action]", Name = "LoginAction")]
    public IActionResult Login([FromServices] ITestService testService, LoginViewModel model)
    {
        Console.WriteLine(Response.Body);
        return Json(new { test = testService.Show(), test2 = model });
    }
}