using Core;
using Core.Context;
using Core.Entites;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastracture
{
    public class StoreContextSeed
    {

        public static async Task SeedAsync(JungleJumboreeDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.Locations != null && !context.Locations.Any())
                {
                    var locationData = File.ReadAllText("..\\Infrastructure\\SeedData\\Location.json");
                    var locations = JsonSerializer.Deserialize<List<Location>>(locationData); //kda 7wlna el json l list
                    if (locations is not null)
                    {
                        foreach (var location in locations)
                        {
                            await context.Locations.AddAsync(location);

                        }
                        await context.SaveChangesAsync();
                    }

                }

                if (context.BirthdayParty != null && !context.BirthdayParty.Any())
                {
                    var Partytype = File.ReadAllText("..\\Infrastructure\\SeedData\\BirthdayParty.json");
                    var parties = JsonSerializer.Deserialize<List<BirthdayParty>>(Partytype); //kda 7wlna el json l list
                    if (parties is not null)
                    {
                        foreach (var party in parties)
                        {
                            await context.BirthdayParty.AddAsync(party);

                        }
                        await context.SaveChangesAsync();
                    }
                }

                if (context.Camps != null && !context.Camps.Any())
                {
                    var campData = File.ReadAllText("..\\Infrastructure\\SeedData\\Camp.json");
                    var camps = JsonSerializer.Deserialize<List<Camp>>(campData); //kda 7wlna el json l list
                    if (camps is not null)
                    {
                        foreach (var camp in camps)
                        {
                            await context.Camps.AddAsync(camp);

                        }
                            await context.SaveChangesAsync();
                    }
                }
                if (context.Crews != null && !context.Crews.Any())
                {
                    var crewData = File.ReadAllText("..\\Infrastructure\\SeedData\\Crew.json");
                    var crews = JsonSerializer.Deserialize<List<Crew>>(crewData); //kda 7wlna el json l list
                    if (crews is not null)
                    {

                        foreach (var crew in crews)
                        {
                            await context.Crews.AddAsync(crew);

                            await context.SaveChangesAsync();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}

