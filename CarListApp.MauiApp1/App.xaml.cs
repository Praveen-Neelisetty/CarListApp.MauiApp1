using CarListApp.MauiApp1.Services;

namespace CarListApp.MauiApp1
{
    public partial class App : Application
    {
        public static CarService CarService { get; private set; }
        public App(CarService carService)
        {
            InitializeComponent();

            MainPage = new AppShell();
            CarService = carService;
        }
    }
}
