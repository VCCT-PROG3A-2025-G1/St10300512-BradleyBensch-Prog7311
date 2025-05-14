using Microsoft.AspNetCore.Mvc;
using St10300512_AgriEnergy.Data;
using St10300512_AgriEnergy.Models;

namespace St10300512_AgriEnergy.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult AdminView()
        {
            return View();
        }

        // Handle form submission
        [HttpPost]
        public async Task<IActionResult> AdminView(string fullName, string location, string phoneNumber, string email, string password, string username)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Username = username,
                    Password = password,
                    Role = "Farmer",
                    Email = email,
                    CreatedAt = DateTime.Now,
                    FullName = fullName,
                    Location = location,
                    PhoneNumber = phoneNumber
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                ViewBag.Message = "Farmer successfully added!";
                ViewBag.GeneratedUsername = username;
                ModelState.Clear();
                return View();
            }

            ViewBag.Error = "Error: Please fill all required fields.";
            return View();
        }

    }
}
