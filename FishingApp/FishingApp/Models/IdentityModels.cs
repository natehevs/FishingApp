using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FishingApp.Models
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

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<FishingApp.Models.LocationMarkers> LocationMarkers { get; set; }

        public System.Data.Entity.DbSet<FishingApp.Models.Enthusiast> Enthusiasts { get; set; }

        public System.Data.Entity.DbSet<FishingApp.Models.Gear> Gears { get; set; }

        public System.Data.Entity.DbSet<FishingApp.Models.TechniqueModel> TechniqueModels { get; set; }
        public IEnumerable<object> RatingController { get; internal set; }
        public object RatingModel { get; internal set; }
    }
}