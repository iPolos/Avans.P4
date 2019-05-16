using System;
using System.Collections.Generic;
using System.Windows.Input;
using AV.DoToo.KlasB.ViewModels;
using Xamarin.Forms;

namespace AV.DoToo.KlasB.Views
{
    public partial class MainView : ContentPage
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;

            ItemsListView.ItemSelected += (s, e) =>
                ItemsListView.SelectedItem = null;
        }
    }
}
