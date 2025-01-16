using Microsoft.EntityFrameworkCore;

namespace CarListApp.Api
{
    public class CarListDbContext : DbContext
    {
        public CarListDbContext(DbContextOptions<CarListDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Make = "Volvo",
                    Model = "Q7",
                    Vin = "123"
                },
                new Car
                {
                    Id = 2,
                    Make = "Benz",
                    Model = "GLE",
                    Vin = "456"
                },
                new Car
                {
                    Id = 3,
                    Make = "Audi",
                    Model = "A6",
                    Vin = "789"
                },
                new Car
                {
                    Id = 4,
                    Make = "BMW",
                    Model = "X5",
                    Vin = "012"
                },
                new Car
                {
                    Id = 5,
                    Make = "RangeRover",
                    Model = "Velar",
                    Vin = "345"
                },
                new Car
                {
                    Id = 6,
                    Make = "Jaguar",
                    Model = "XE",
                    Vin = "678"
                },
                new Car
                {
                    Id = 7,
                    Make = "Suzuki",
                    Model = "Swift",
                    Vin = "951"
                },
                new Car
                {
                    Id = 8,
                    Make = "Honda",
                    Model = "Amaze",
                    Vin = "753"
                },
                new Car
                {
                    Id = 9,
                    Make = "Tata",
                    Model = "Punch",
                    Vin = "456"
                },
                new Car
                {
                    Id = 10,
                    Make = "Mahindra",
                    Model = "Thar",
                    Vin = "555"
                }
            );
        }
    }
}