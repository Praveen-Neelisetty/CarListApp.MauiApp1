using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CarListApp.MauiApp1.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListApp.MauiApp1.ViewModels
{
    //[QueryProperty(nameof(Car), "Car")]
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class CarDetailsPageViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        Car car;

        [ObservableProperty]
        int id;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));//(int)query["id"]; --> in this may get Exception
            Car = App.CarService.GetCar(Id);
        }
    }
}
