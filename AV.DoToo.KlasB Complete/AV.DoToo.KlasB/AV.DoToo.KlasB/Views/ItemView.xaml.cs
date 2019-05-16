using System;
using System.Collections.Generic;
using AV.DoToo.KlasB.ViewModels;
using Xamarin.Forms;

namespace AV.DoToo.KlasB.Views
{
    public partial class ItemView : ContentPage
    {
        public ItemView(ItemViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }
    }
}
