using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using St10300512_AgriEnergy.Data;
using St10300512_AgriEnergy.Models;
using St10300512_AgriEnergy.Models.ViewModels;

public class FarmerController : Controller
{
    private readonly AppDbContext _context;

    public FarmerController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult CreateProduct()
    {
        return View();
    }

    [HttpPost]
public async Task<IActionResult> CreateProduct(Product product)
{
    // Check if UserId is being used
    var userIdString = HttpContext.Session.GetString("UserId");

    if (string.IsNullOrEmpty(userIdString))
    {
        // If not found, handle error
        TempData["Error"] = "You must be logged in to add a product.";
        return RedirectToAction("LoginView", "Account");
    }

    // Attempt to parse the ID
    if (!int.TryParse(userIdString, out int userId))
    {
            // Handle the case if parsing fails
        TempData["Error"] = "Invalid user session.";
        return RedirectToAction("LoginView", "Account");
    }

    // Set the ID for the product, if it passes
    product.UserId = userId;

    // Add Product to database
    if (ModelState.IsValid)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        TempData["Message"] = "Product added successfully!";
        return RedirectToAction("FarmerView");
    }

        // Debugging
        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
    {
        Console.WriteLine(error.ErrorMessage);  
    }

    TempData["Error"] = "Please complete all required fields.";
    return View(product);  
}

    // Handles Filtering for Date, Category, and Farmer
    [HttpGet]
    public IActionResult FarmerView(string categoryFilter, DateTime? startDate, DateTime? endDate, string farmerFilter)
    {
        var productsQuery = _context.Products
            .Include(p => p.User)
            .AsQueryable();

        if (!string.IsNullOrEmpty(categoryFilter))
        {
            productsQuery = productsQuery.Where(p => p.Category.ToLower() == categoryFilter.ToLower());
        }

        if (!string.IsNullOrEmpty(farmerFilter))
        {
            productsQuery = productsQuery.Where(p => p.User.FullName.ToLower().Contains(farmerFilter.ToLower()));
        }

        if (startDate.HasValue)
        {
            productsQuery = productsQuery.Where(p => p.ProductionDate >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            productsQuery = productsQuery.Where(p => p.ProductionDate <= endDate.Value);
        }

        var products = productsQuery.Select(p => new ProductViewModel
        {
            Name = p.Name,
            Description = p.Description,
            Category = p.Category,
            ProductionDate = p.ProductionDate,
            FarmerName = p.User.FullName
        }).ToList();

        return View(products);
    }


}
