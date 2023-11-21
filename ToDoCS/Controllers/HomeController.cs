using Microsoft.AspNetCore.Mvc;

namespace ToDoCS.Controllers;
public class HomeController : Controller
{
    [HttpGet]
    [Route("")]
    [Route("[controller]/[action]")]
    public IActionResult Index()
    {
        return View();
    }
}