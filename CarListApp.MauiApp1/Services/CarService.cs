using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarListApp.MauiApp1.Models;
using SQLite;

namespace CarListApp.MauiApp1.Services
{
    public class CarService
    {
        private SQLiteConnection connection;
        string _dbPath;
        public string StatusMessage;
        int result = 0;

        public CarService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (connection != null)
            {
                return;
            }
            connection = new SQLiteConnection(_dbPath);
            connection.CreateTable<Car>();
        }

        public List<Car> GetCars()
        {
            try
            {
                Init();
                var res = connection.Table<Car>().ToList();
                return res;
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrive the data";
                Console.WriteLine(ex.Message);
            }
            return new List<Car>();

            /*
            return new List<Car>()
            {
                new Car
                {
                    Id = 1, Make = "Volvo", Model = "Q7", Vin = "123"    
                },
                new Car
                {
                    Id = 2, Make = "Benz", Model = "GLE", Vin = "456"
                },
                new Car
                {
                    Id = 3, Make = "Audi", Model = "A6", Vin = "789"
                },
                new Car
                {
                    Id = 4, Make = "BMW", Model = "X5", Vin = "012"
                },
                new Car
                {
                    Id = 5, Make = "RangeRover", Model = "Velar", Vin = "345"
                },
                new Car
                {
                    Id = 6, Make = "Jaguar", Model = "XE", Vin = "678"
                },
            }; */
        }

        public void AddCar(Car car)
        {
            try
            {
                Init();
                if (car == null)
                {
                    throw new Exception("Invalid Car Record");
                }

                result = connection.Insert(car);
                StatusMessage = result == 0 ? "Insert Failed" : "Insert Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to Insert data";
            }
        }

        public int DeleteCar(int id)
        {
            try
            {
                Init();
                return connection.Table<Car>().Delete(q => q.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to delete data";
            }
            return 0;
        }

        public Car GetCar(int id)
        {
            try
            {
                Init();
                return connection.Table<Car>().FirstOrDefault(q => q.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data";
            }

            return null;
        }

        public void UpdateCar(Car car)
        {
            try
            {
                Init();
                if (car == null)
                {
                    throw new Exception("Invalid car record");
                }

                result = connection.Update(car);
                StatusMessage = result == 0 ? "Update failed" : "Update Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to Update Data";
            }
        }
    }
}
