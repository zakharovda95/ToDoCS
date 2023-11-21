using Microsoft.AspNetCore.Mvc;

namespace ToDoCS.Controllers;

public class LoginController: Controller
{
    [HttpGet]
    [Route("Auth/[controller]")]
    [Route("Auth/[controller]/[action]")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("/api/Auth/[controller]/[action]")]
    public IActionResult Login(string name, string password)
    {
        return Json(new { name, password });
    }
}