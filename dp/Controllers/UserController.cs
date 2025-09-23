using dp.Models;
using dp.Services;
using dp.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = new User
        {
            FullName = model.FullName,
            Email = model.Email,
            Role = UserRole.User
        };

        try
        {
            var result = await _userService.RegisterAsync(user, model.Password);
            HttpContext.Session.SetInt32("UserId", result.Id);
            HttpContext.Session.SetString("Role", result.Role.ToString());
            return RedirectToAction("Index", "Event");
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError("Email", ex.Message);
            return View(model);
        }
    }


    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = await _userService.LoginAsync(model.Email, model.Password);
        if (user == null) return View("LoginFailed");

        HttpContext.Session.SetInt32("UserId", user.Id);
        HttpContext.Session.SetString("Role", user.Role.ToString());

        return RedirectToAction("Index", "Event");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Event");
    }

    public async Task<IActionResult> ListUser()
    {
        var users = await _userService.GetAllUsers();
        return View(users);
    }
}
