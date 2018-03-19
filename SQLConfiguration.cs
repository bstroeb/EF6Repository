using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EF6Repository.Entities;

namespace EF6Repository
{
    internal sealed class SQLConfiguration : DbMigrationsConfiguration<SQLDbContext>
    {

        public SQLConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SQLDbContext context)
        {
            
            EF6Repository.Seed.Seed_Roles(context, new List<ApplicationRole> { 
                new ApplicationRole{ Name="Site Administrator"}
            });

            EF6Repository.Seed.Seed_Users(context, new List<ApplicationUser> { 
                new ApplicationUser{
                    UserName="testuser",
                    Email="testuser@example.com",
                    firstname = "Test",
                    lastname = "User"
                }
            });
        }

    }

}
