
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarListApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(o =>
            {
                o.AddPolicy("AllowAll", a => a.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

            var dbPath = Path.Join(Directory.GetCurrentDirectory(), "carlist.db");
            var connection = new SqliteConnection($"Data Source={dbPath}");
            builder.Services.AddDbContext<CarListDbContext>(o => o.UseSqlite(connection));

            var app = builder.Build();
            
            // Till here we have builde on the Top where we are building all our services and then app says okay--> Compile all services.
            // Now let us start putting in the different itself Middleware   

            // From here is considered as --> Middleware

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll"); // So It Implements the policy right before we run. 

            app.UseAuthorization();

            app.MapGet("/cars", async (CarListDbContext db) => await db.Cars.ToListAsync());
            
            app.MapGet("/cars/{id}", async (CarListDbContext db, int id) => 
            await db.Cars.FindAsync(id) is Car car ? Results.Ok(car) : Results.NotFound());

            app.MapPut("/cars/{id}", async (CarListDbContext db, int id, Car car) =>
            {
                var record = await db.Cars.FindAsync(id);
                if (record == null)
                {
                    return Results.NotFound();
                }
                record.Make = car.Make;
                record.Model = car.Model;
                record.Vin = car.Vin;

                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            app.MapDelete("/cars/{id}", async (CarListDbContext db, int id) =>
            {
                var record = await db.Cars.FindAsync(id);
                if (record == null)
                { 
                    return Results.NotFound();
                }
                db.Remove(record);
                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            app.MapPost("/cars", async (CarListDbContext db, Car car, int id) =>
            {
                await db.AddAsync(car);
                await db.SaveChangesAsync();
                return Results.Created($"/cars/{car.Id}", car);
            });

            /* This is Test data we can remove but for reference we can keep
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi(); 
            */

            app.Run();
        }
    }
}
