using System;
using System.Collections.Generic;
using AV.DoToo.KlasA.ViewModels;
using Xamarin.Forms;

namespace AV.DoToo.KlasA.Views
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
