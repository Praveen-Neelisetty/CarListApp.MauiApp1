﻿using CarListApp.MauiApp1.ViewModels;

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
