using Core.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastracture
{
    public class AppIdentityContextSeed
    {
        public static async Task SeedUserAsync(UserManager<Users> userManager)
        {
            if(!userManager.Users.Any())
            {
                var userData = File.ReadAllText("..\\Infrastructure\\SeedData\\Users.json");
                var users = JsonSerializer.Deserialize<List<Users>>(userData); //kda 7wlna el json l list
                if (users is not null)
                {
                    foreach (var user in users)
                    {
                        user.UserName = user.Email.Split('@').First();
                        var result = await userManager.CreateAsync(user, "Password123!");

                    }
                    
                }
                
            }
        }
    }
}
