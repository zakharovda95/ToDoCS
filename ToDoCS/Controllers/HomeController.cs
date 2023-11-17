using Microsoft.AspNetCore.Mvc;

namespace ToDoCS.Controllers;

[Route("{controller}")]
public class HomeController : Controller
{
    [HttpGet]
    [Route("")]
    [Route("/")]
    [Route("{action}")]
    public IActionResult Index()
    {
        return View();
    }
}