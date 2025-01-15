using CarListApp.MauiApp1.ViewModels;

namespace CarListApp.MauiApp1.Views;

public partial class CarDetailsPage : ContentPage
{
	public CarDetailsPage(CarDetailsPageViewModel carDetailsPageViewModel)
	{
		InitializeComponent();
		BindingContext = carDetailsPageViewModel; 
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}