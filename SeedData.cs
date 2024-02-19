using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LibApp.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            if (!roleManager.RoleExistsAsync("Editor").Result)
            {
                var role = new IdentityRole("Editor");
                var roleResult = roleManager.CreateAsync(role).Result;
            }

            var userEmail = "Piotr@gmail.com";
            var user = userManager.FindByEmailAsync(userEmail).Result;
            if (user != null && !userManager.IsInRoleAsync(user, "Editor").Result)
            {
                var result = userManager.AddToRoleAsync(user, "Editor").Result;
            }
        }
    }
}
