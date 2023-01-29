using ColorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ColorAPI
{
    public static class PrepDb
    {
        public static IConfiguration? _configuration;
        public static bool _migrateDatabase;  

        public async static void PrepPopulation(IApplicationBuilder app, IConfiguration configuration) 
        {
            _configuration = configuration;
            try 
            {
                _migrateDatabase = bool.Parse(_configuration["MigrateDatabase"]);
            }
            catch 
            {
                _migrateDatabase = false;
            }

            using (var serviceScope = app.ApplicationServices.CreateScope()) 
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ColourDbContext>();
                if(dbContext== null) 
                {
                    throw new Exception($"No DbConext found in type of {nameof(ColourDbContext)}");
                }

                if (_migrateDatabase == true) 
                {
                    Console.WriteLine("Database migrating");

                    await dbContext.Database.MigrateAsync();
                }
                await SeedDataAsync(dbContext);
            }
        }

        private async static Task SeedDataAsync(ColourDbContext context) 
        {
            if (!context.Colours.Any()) 
            {
                Console.WriteLine("Seeding data");

                context.Colours.AddRange(new List<Colour>
                {
                    new Colour
                    {
                        Id = Guid.NewGuid(),
                        Name = "Brown"
                    },
                    new Colour 
                    {
                        Id = Guid.NewGuid(),
                        Name = "Red"
                    },
                    new Colour 
                    {
                        Id = Guid.NewGuid(),
                        Name = "Green"
                    }
                });

                await context.SaveChangesAsync();
            }
            else 
            {
                Console.WriteLine("Already have data");
            }
        }
    }
}
