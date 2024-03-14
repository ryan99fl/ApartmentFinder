using ApartmentFinder.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ApartmentFinder.Models
{
    public class ConfigureIdentity
    {
        public static async Task CreateAdminUserAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<InternalUser>>();

            string roleName = "Admin";
            string username = "rsouthwell";
            string password = "password1234!";
            string firstName = "Ryan";
            string lastName = "Southwell";

            if (await roleManager.FindByIdAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            if (await userManager.FindByIdAsync(username) == null)
            {
                InternalUser user = new InternalUser { UserName = username, FirstName = firstName, LastName = lastName };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }

            }
            
        }
    }
}
