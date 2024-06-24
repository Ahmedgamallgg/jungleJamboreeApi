using Core.Context;
using Core.Entites;
using Infrastracture;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_session_1.Helper
{
    public class ApplySeeding
    {
        public static async Task ApplySeedingAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serivces = scope.ServiceProvider;
                var loggerFactory = serivces.GetRequiredService<ILoggerFactory>();

                try
                {

                    var context = serivces.GetRequiredService<JungleJumboreeDbContext>();
                    var userManager = serivces.GetRequiredService<UserManager<Users>>();
                    await context.Database.MigrateAsync();
                    await AppIdentityContextSeed.SeedUserAsync(userManager);
                    await StoreContextSeed.SeedAsync(context, loggerFactory);

                }
                catch (Exception ex)
                {

                    var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                    logger.LogError(ex.Message); ;
                }
            }
        }
    }
}
