namespace St10300512_AgriEnergy.Models
{
    public class User
    {
        public int UserId { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FullName { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
