using Microsoft.AspNetCore.Identity;

namespace PangandusProjectv1.Data
{
    public static class SeedRoles
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            string[] roleNames = { "Admin", "User" }; 

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole<Guid>
                    {
                        Name = roleName,
                        NormalizedName = roleName.ToUpper()
                    });
                }
            }
        }
    }
}
