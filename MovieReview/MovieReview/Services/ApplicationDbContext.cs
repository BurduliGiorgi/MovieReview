using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieReview.Models;

namespace MovieReview.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var RegisteredUser = new IdentityRole("RegisteredUser");
            RegisteredUser.NormalizedName = "RegisteredUser";

            var GuestUser = new IdentityRole("GuestUser");
            GuestUser.NormalizedName = "GuestUser";

            builder.Entity<IdentityRole>().HasData(admin, RegisteredUser,GuestUser);
        }
    }
}
