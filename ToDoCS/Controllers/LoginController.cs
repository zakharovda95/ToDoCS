using Microsoft.AspNetCore.Mvc;

namespace ToDoCS.Controllers;

[Route("Auth/{controller}")]
public class LoginController: Controller
{
    [HttpGet]
    [Route("")]
    [Route("{action}")]
    public IActionResult Index()
    {
        return View();
    }
}