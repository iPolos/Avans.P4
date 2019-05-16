using System;
using System.Collections.Generic;
using AV.DoToo.KlasA.ViewModels;
using Xamarin.Forms;

namespace AV.DoToo.KlasA.Views
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
