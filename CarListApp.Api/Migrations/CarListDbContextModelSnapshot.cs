﻿// <auto-generated />
using CarListApp.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarListApp.Api.Migrations
{
    [DbContext(typeof(CarListDbContext))]
    partial class CarListDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("CarListApp.Api.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Make = "Volvo",
                            Model = "Q7",
                            Vin = "123"
                        },
                        new
                        {
                            Id = 2,
                            Make = "Benz",
                            Model = "GLE",
                            Vin = "456"
                        },
                        new
                        {
                            Id = 3,
                            Make = "Audi",
                            Model = "A6",
                            Vin = "789"
                        },
                        new
                        {
                            Id = 4,
                            Make = "BMW",
                            Model = "X5",
                            Vin = "012"
                        },
                        new
                        {
                            Id = 5,
                            Make = "RangeRover",
                            Model = "Velar",
                            Vin = "345"
                        },
                        new
                        {
                            Id = 6,
                            Make = "Jaguar",
                            Model = "XE",
                            Vin = "678"
                        },
                        new
                        {
                            Id = 7,
                            Make = "Suzuki",
                            Model = "Swift",
                            Vin = "951"
                        },
                        new
                        {
                            Id = 8,
                            Make = "Honda",
                            Model = "Amaze",
                            Vin = "753"
                        },
                        new
                        {
                            Id = 9,
                            Make = "Tata",
                            Model = "Punch",
                            Vin = "456"
                        },
                        new
                        {
                            Id = 10,
                            Make = "Mahindra",
                            Model = "Thar",
                            Vin = "555"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
