using CarListApp.MauiApp1.ViewModels;
using Microsoft.Maui.Devices;

namespace CarListApp.MauiApp1
{
    public partial class MainPage : ContentPage
    {
        //int count = 0;

        public MainPage(CarListViewModel carListViewModel)
        {
            InitializeComponent();
            BindingContext = carListViewModel;
        }

        private void Make_Completed(object sender, EventArgs e)
        {
            Model.Focus(); // Move focus to the Model Entry
        }

        private void Model_Completed(object sender, EventArgs e)
        {
            Vin.Focus(); // Move focus to the Vin Entry
        }

        private void Vin_Completed(object sender, EventArgs e)
        {
            var entry = sender as Entry; // Cast sender to Entry
            Console.WriteLine($"User entered: {entry.Text}");

            Vin.Unfocus(); // Close the keyboard
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(50)); // Add vibration
        }


        /*
        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        */
    }

}
