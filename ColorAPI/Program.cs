using Microsoft.EntityFrameworkCore;

namespace ColorAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration["DB_CONNECTION_STRING"];

            builder.Services.AddDbContext<ColourDbContext>(options =>
                options.UseNpgsql(connectionString));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            PrepDb.PrepPopulation(app, builder.Configuration);

            app.MapControllers();

            app.Run();
        }
    }
}