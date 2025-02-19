using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataBaseContext
{
    public  class IdentitySeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!userManager.Users.Any()) { 
                // Ensure roles exist
                await EnsureRoleExists(roleManager, "Admin");
                await EnsureRoleExists(roleManager, "User");

                // Create Admin user
                await EnsureUserExists(userManager, "Ali", "Ali@Admin.com", "Admin");

                // Create Regular User
                await EnsureUserExists(userManager, "Ali", "Ali@User.com", "User");
            }
        }

        private static async Task EnsureRoleExists(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        private static async Task EnsureUserExists(UserManager<AppUser> userManager, string name, string email, string role)
        {
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new AppUser
                {
                    Name = name,
                    Email = email,
                    UserName = email
                };

                var result = await userManager.CreateAsync(user, "P@$$w0rd");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}