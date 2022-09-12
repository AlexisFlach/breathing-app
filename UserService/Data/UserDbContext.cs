using UserService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace UserService.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser>
    {

        public UserDbContext() { }
        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<User> Users { get; set; }
        
    }
}