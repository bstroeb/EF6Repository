using EF6Repository.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EF6Repository
{
    public class SQLDbContext : IdentityDbContext<ApplicationUser>
    {

        public SQLDbContext()
            : base("dbContext", throwIfV1Schema: false)
        {
        }

        static SQLDbContext()
        {
            Database.SetInitializer<SQLDbContext>(new MigrateDatabaseToLatestVersion<SQLDbContext, SQLConfiguration>());
        }

        public static SQLDbContext Create()
        {
            return new SQLDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //rename aspnet tables
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            // Remove cascade delete from build for now
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        }
    }
}
