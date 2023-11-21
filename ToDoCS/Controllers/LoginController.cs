using Microsoft.AspNetCore.Mvc;
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
    public IActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
            return Json(new { name = model.Name, password = model.Password });
        
        return Json(new {name = ModelState["name"].Errors[0].ErrorMessage, password = ModelState["password"].Errors[0].ErrorMessage });
    }
}