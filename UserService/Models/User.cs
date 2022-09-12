using Microsoft.AspNetCore.Identity;

namespace UserService.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public List<Exercise>? Exercises { get; set; }
    }
}