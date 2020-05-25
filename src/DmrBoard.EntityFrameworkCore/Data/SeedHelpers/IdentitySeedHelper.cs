using DmrBoard.Core.Authorization.Roles;
using DmrBoard.Core.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmrBoard.EntityFrameworkCore.Data.SeedHelpers
{

    public class IdentitySeedHelper
    {
        public static async Task CreateUserAndRoles(IServiceScope serviceScope, DmrDbContext dbContext)
        {
            var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<Role>>();
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

            dbContext.Database.EnsureCreated();

            await CreateRoles(dbContext, roleManager);
            await CreateUser(dbContext, userManager);

            await dbContext.SaveChangesAsync();
        }


        private async static Task CreateUser(DmrDbContext dbContext, UserManager<User> userManager)
        {
            var user = new User
            {
                FirstName = "Serhat",
                SurName = "Demir",
                Email = "serhat-demir@windowslive.com",
                NormalizedEmail = "SERHAT-DEMIR@WINDOWSLIVE.COM",
                UserName = "serhat-demir@windowslive.com",
                NormalizedUserName = "SERHAT",
                PhoneNumber = "5555555",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            if (!dbContext.Users.Any(k => k.Email == user.Email))
            {
                var passHas = new PasswordHasher<User>();
                user.PasswordHash = passHas.HashPassword(user, "1234568");
                await userManager.CreateAsync(user);

                await AssignRoles(userManager, user.Email, new string[] { "Admin" });
            }
        }
        private async static Task CreateRoles(DmrDbContext dbContext, RoleManager<Role> roleManager)
        {
            List<string> roles = new List<string> { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!dbContext.Roles.Any(k => k.Name == role))
                    await roleManager.CreateAsync(new Role { Name = role });
            }

        }


        private static async Task<IdentityResult> AssignRoles(UserManager<User> userManager, string email, string[] roles)
        {
            var user = await userManager.FindByEmailAsync(email);
            var result = await userManager.AddToRolesAsync(user, roles);
            return result;
        }
    }
}
