using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using EF6Repository.Entities;

namespace EF6Repository
{
    public class Seed
    {
        public static void Seed_Roles(SQLDbContext context, List<ApplicationRole> app_roles)
        {

            SQLDbContext ctx = context;

            foreach (ApplicationRole r in app_roles)
            {
                ApplicationRole role = (ApplicationRole)(from x in ctx.Roles where x.Name == r.Name select x).SingleOrDefault();
                if ((role == null))
                {
                    role = new ApplicationRole(r.Name);
                    role.Description = r.Description;
                    role.active = true;
                    ctx.Roles.Add(role);
                    ctx.SaveChanges();
                }
            }

        }

        public static void Seed_Users(SQLDbContext context, List<ApplicationUser> app_users)
        {
            SQLDbContext ctx = context;

            foreach (ApplicationUser u in app_users)
            {
                ApplicationUser admusr = (from x in ctx.Users where x.UserName == u.UserName select x).SingleOrDefault();
                if ((admusr == null))
                {
                    admusr = new ApplicationUser
                    {
                        UserName = u.UserName,
                        Email = u.Email,
                        PasswordHash = new PasswordHasher().HashPassword("password"), // you will want to change this
                        SecurityStamp = Guid.NewGuid().ToString(),
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        TwoFactorEnabled = false,
                        LockoutEnabled = false,
                        AccessFailedCount = 0
                    };
                    ctx.Users.Add(admusr);
                    ctx.SaveChanges();
                }

                //Add admin user to site admin role
                ApplicationRole role = (ApplicationRole)(from r in ctx.Roles where r.Name == "Site Administrator" select r).SingleOrDefault();
                admusr = (from x in ctx.Users where x.UserName == u.UserName select x).SingleOrDefault();
                IdentityUserRole iur = (from ir in admusr.Roles where ir.RoleId == role.Id select ir).SingleOrDefault();
                if ((role != null) & (admusr != null) & (iur == null))
                {
                    role.Users.Add(new IdentityUserRole
                    {
                        RoleId = role.Id,
                        UserId = admusr.Id
                    });
                    ctx.SaveChanges();
                }
            }
            
        }
    }
}
