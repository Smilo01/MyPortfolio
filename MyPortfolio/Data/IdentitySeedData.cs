using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MyPortfolio.Data
{
    public static class SeedIdentityData
    {
        private const string adminUser = "zikhalismilo01@gmail.com";
        private const string adminPassword = "Zikhalismilo01";
        private const string adminEmail = "zikhalismilo01@gmail.com";
        private const string adminRole = "Admin";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            MyPortfolioDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<MyPortfolioDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            if (await userManager.FindByNameAsync(adminUser) == null)
            {
                if (await roleManager.FindByNameAsync(adminRole) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(adminRole));
                }

                IdentityUser user = new IdentityUser
                {
                    UserName = adminUser,
                    Email = adminEmail
                };

                IdentityResult result = await userManager.CreateAsync(user, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, adminRole);
                }

            }
        }
    }
}
