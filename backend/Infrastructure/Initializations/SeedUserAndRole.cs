using Domain.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Initializations;
public static class SeedUserAndRole
{
    public static async Task Initialize(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
    {
        string adminRoleName = "Admin";
        string adminUserName = "onurt";
        string adminEmail = "onurt@abc.com";
        string adminPhoneNumber = "5xxxxxxxxx";
        string adminPassword = "Arge!234";

        // Ensure the Admin role exists
        if (!await roleManager.RoleExistsAsync(adminRoleName))
        {
            var adminRole = new ApplicationRole { Name = adminRoleName };
            await roleManager.CreateAsync(adminRole);
        }

        // Ensure the Admin user exists
        var adminUser = await userManager.FindByNameAsync(adminUserName);
        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminUserName,
                Email = adminEmail,
                PhoneNumber = adminPhoneNumber,
                Name = "Onur",
                Surname = "Topal"
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, adminRoleName);
            }
        }
        else
        {
            // Ensure the Admin user is in the Admin role
            if (!await userManager.IsInRoleAsync(adminUser, adminRoleName))
            {
                await userManager.AddToRoleAsync(adminUser, adminRoleName);
            }
        }
    }
}