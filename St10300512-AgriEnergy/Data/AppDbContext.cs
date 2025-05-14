using Microsoft.EntityFrameworkCore;
using St10300512_AgriEnergy.Models;

namespace St10300512_AgriEnergy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

       

    }
}
