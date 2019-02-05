using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataModel.Entity
{
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
    public class ProjectInitializer : DropCreateDatabaseIfModelChanges<ContextDB>
    {
        protected override void Seed(ContextDB context)
        {
        }
    }

    public class ContextDB : IdentityDbContext<ApplicationUser, IdentityRole, string, IdentityUserLogin,
        IdentityUserRole, IdentityUserClaim>
    {
        public static ContextDB Create()
        {
            return new ContextDB();
        }

        public ContextDB()
            : base("DefaultConnection")
        {
        }

        public virtual DbSet<Film> Films { get; set; }


    }
}
