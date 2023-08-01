namespace IMS.WEB.Migrations
{
    using IMS.WEB.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IMS.WEB.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IMS.WEB.Models.ApplicationDbContext context)
        {
            // Check if an admin user already exists (optional, you can skip this if needed)
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var adminUser = userManager.FindByName("admin@example.com");
            if (adminUser == null)
            {
                // Create a new admin user
                var adminEmail = "admin@ims.com";
                var adminPassword = "123456"; // Replace with the desired password for the admin user

                var admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true // You can set this to false and handle email confirmation if needed
                };

                // Create the admin user
                var result = userManager.Create(admin, adminPassword);

                // If the user was successfully created, add them to the "Admin" role (optional)
                if (result.Succeeded)
                {
                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                    var adminRoleName = "Admin";

                    // Check if the "Admin" role already exists (optional, you can skip this if needed)
                    if (!roleManager.RoleExists(adminRoleName))
                    {
                        // Create the "Admin" role
                        var adminRole = new IdentityRole { Name = adminRoleName };
                        roleManager.Create(adminRole);
                    }

                    // Assign the admin user to the "Admin" role
                    userManager.AddToRole(admin.Id, adminRoleName);
                }
            }
        }
    }
}
