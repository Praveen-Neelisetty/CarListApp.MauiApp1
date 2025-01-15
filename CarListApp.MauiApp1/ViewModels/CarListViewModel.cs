using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CarListApp.MauiApp1.Models;
using CarListApp.MauiApp1.Services;
using CarListApp.MauiApp1.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace CarListApp.MauiApp1.ViewModels
{
    public partial class CarListViewModel : BaseViewModel
    {
        //public CarService carService; // remove later
        public ObservableCollection<Car> Cars { get; private set; } = new ObservableCollection<Car>();
        const string editButtonText = "Update Car";
        const string createButtonText = "Add Car";

        public CarListViewModel()
        {
            Title = "Car List";
            AddEditButtonText = createButtonText;
            GetCarList().Wait();
            //this.carService = carService; // remove later
        }

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string make;

        [ObservableProperty]
        string model;

        [ObservableProperty]
        string vin;

        [ObservableProperty]
        string addEditButtonText;

        [ObservableProperty]
        int carId;





        [RelayCommand]
        async Task GetCarList()
        {
            if (IsLoading)
            {
                return;
            }
            try
            {
                IsLoading = true;
                if (Cars.Any())
                {
                    Cars.Clear();
                }
                var cars = App.CarService.GetCars();
                foreach (var car in cars)
                {
                    Cars.Add(car);
                }

                /*// Handling Save and Read File // remove later

                // Saving Text (Json) into file
                string fileName = "carList.json";
                var carList = JsonSerializer.Serialize(Cars);
                File.WriteAllText(fileName, carList);
                
                // Reading a File
                var rawText = File.ReadAllText(fileName);
                var carsFromText = JsonSerializer.Deserialize<List<Car>>(rawText);

                // Get App Directory
                string path = FileSystem.AppDataDirectory;
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //Just like if you want the path of folder we can use like this */

                /*
                  For Setting up Sqlite 
                  1) sqlite-net-pcl
                  2) sqlitepclraw.provider.dynamic_cdecl
                 */
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get cars: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to retrive list of cars.", "OK");
            }
            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GetCarDetails(int id)
        {
            if(id == 0)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(CarDetailsPage)}?Id={id}",true);
        }

        /* If you want to pass whole object you can use this one
        [RelayCommand]
        async Task GetCarDetails(Car car)
        {
            if (car == null)
                return;
            await Shell.Current.GoToAsync(nameof(CarDetailsPage), true, new Dictionary<string, object>
            {
                { nameof(Car),car }
            });
        } */

        [RelayCommand]
        async Task SaveCar()
        {
            if (string.IsNullOrEmpty(Make) || string.IsNullOrEmpty(Model) || string.IsNullOrEmpty(Vin))
            {
                await Shell.Current.DisplayAlert("Invalid Data", "Please Insert Valid Data", "Ok");
                return;
            }

            var car = new Car
            {
                Make = Make,
                Model = Model,
                Vin = Vin,
            };

            if (CarId != 0)
            {
                car.Id = CarId;
                App.CarService.UpdateCar(car);
                await Shell.Current.DisplayAlert("Info", App.CarService.StatusMessage, "Ok");
            }
            else
            {
                App.CarService.AddCar(car);
                await Shell.Current.DisplayAlert("Info", App.CarService.StatusMessage, "Ok");
            }

            var cars = App.CarService.GetCars();
            await GetCarList();
            await ClearForm();
        }

        [RelayCommand]
        async Task DeleteCar(int id)
        {
            if (id == 0)
            {
                await Shell.Current.DisplayAlert("Invalid Record", "Please try again", "Ok");
                return;
            }
            var result = App.CarService.DeleteCar(id);
            if(result == 0)
            {
                await Shell.Current.DisplayAlert("Failed", "Please Insert Valid Data", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Deletion Successfully", "Record Removed Successfully", "Ok");
                await GetCarList();
            }
        }

        [RelayCommand]
        async Task SetEditMode(int id)
        {
            AddEditButtonText = editButtonText;
            CarId = id;
            var car = App.CarService.GetCar(id);
            Make = car.Make;
            Model = car.Model;
            Vin = car.Vin;
        }

        [RelayCommand]
        async Task ClearForm()
        {
            AddEditButtonText = createButtonText;
            CarId = 0;
            Make = string.Empty;
            Model = string.Empty;
            Vin = string.Empty;
        }
    }
}
