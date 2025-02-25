public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _userService.ValidateUser(username, password);
        if (user != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var identity = new ClaimsIdentity(claims, "login");
            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(principal);
            return RedirectToAction("Dashboard");
        }
        
        return View("LoginFailed");
    }
}
