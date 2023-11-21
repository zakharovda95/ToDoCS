using Microsoft.AspNetCore.Mvc;

namespace ToDoCS.Controllers;
public class RegistrationController: Controller
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
    public IActionResult Register(string name, string password, string passwordRepeat, string email)
    {
        return Json(new { name, password, passwordRepeat, email });
    }
}