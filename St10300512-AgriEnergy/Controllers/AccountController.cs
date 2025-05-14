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

        public IActionResult LoginView()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                // Get user by username
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

                if (user != null)
                {
                    // Check password
                    if (user.Password == password) 
                    {
                        // Set session values
                        HttpContext.Session.SetString("Username", user.Username);
                        HttpContext.Session.SetString("Role", user.Role);
                        HttpContext.Session.SetString("UserId", user.UserId.ToString());

                        // Successful login
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Invalid password
                        ModelState.AddModelError(string.Empty, "Invalid password.");
                    }
                }
                else
                {
                    // User not found
                    ModelState.AddModelError(string.Empty, "Invalid username.");
                }

                // Return the view with the errors
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login error: {ex.Message}"); 
                Console.WriteLine($"Stack Trace: {ex.StackTrace}"); 
                ViewBag.Error = $"An error occurred during login: {ex.Message}";  // Show the error message to the user
                return View();
            }
        }



    }

}
