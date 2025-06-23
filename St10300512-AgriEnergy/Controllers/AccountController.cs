using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using St10300512_AgriEnergy.Data;

namespace St10300512_AgriEnergy.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("LoginView"); // Explicitly using LoginView.cshtml
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

                if (user != null)
                {
                    if (user.Password == password)
                    {
                        HttpContext.Session.SetString("Username", user.Username);
                        HttpContext.Session.SetString("Role", user.Role);
                        HttpContext.Session.SetString("UserId", user.UserId.ToString());

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid password.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username.");
                }

                return View("LoginView"); // Also explicitly rendering LoginView.cshtml on failure
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                ViewBag.Error = $"An error occurred during login: {ex.Message}";
                return View("LoginView");
            }
        }
    }
}
