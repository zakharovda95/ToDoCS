using Microsoft.AspNetCore.Mvc;

namespace ToDoCS.Controllers;
public class RegistrationController: Controller
{
    [HttpGet]
    [Route("Auth/[controller]", Name = "RegisterIndex")]
    [Route("Auth/[controller]/[action]", Name = "RegisterIndexAction")]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    [Route("/api/Auth/[controller]/[action]", Name = "RegisterAction")]
    public IActionResult Register(string name, string password, string passwordRepeat, string email)
    {
        return Json(new { name, password, passwordRepeat, email });
    }
}