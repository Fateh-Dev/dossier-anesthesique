using Microsoft.AspNetCore.Identity;
using Server.Net.Models;

namespace Server.Net.Data;

public static class DbSeeder
{
    public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
    {
        //Seed Roles
        var userManager = service.GetService<UserManager<ApplicationUser>>();
        var roleManager = service.GetService<RoleManager<IdentityRole>>();
        
        if (roleManager == null || userManager == null) return;

        await roleManager.CreateAsync(new IdentityRole("Admin"));
        await roleManager.CreateAsync(new IdentityRole("User"));

        // Creating Admin User
        // var user = new ApplicationUser
        // {
        //     UserName = "admin@gmail.com",
        //     Email = "admin@gmail.com",
        //     EmailConfirmed = true,
        //     PhoneNumberConfirmed = true
        // };
        // var userInDb = await userManager.FindByEmailAsync(user.Email);
        // if (userInDb == null)
        // {
        //     await userManager.CreateAsync(user, "Admin@123");
        //     await userManager.AddToRoleAsync(user, "Admin");
        // }
    }
}
