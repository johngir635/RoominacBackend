using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RoominacBackend.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<RoominacUsers> RoominacUsers { get; set; }
      
        public DbSet<WishlistItem> WishlistItem { get; set; }
        public DbSet<PersonalInformation> PersonalInformation { get; set; }
        public DbSet<PaymentHistory> PaymentHistory { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<PropertyDetail> PropertyDetail { get; set; }
        public DbSet<PropertyItemImage> PropertyItemImage { get; set; }
        public DbSet<Stays> Stays { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<ReportedSuperHostProfile> ReportedSuperHostProfile { get; set; }
        public DbSet<SuperHost> SuperHost { get; set; }
        public DbSet<TopTierStays> TopTierStays { get; set; }
    }
}