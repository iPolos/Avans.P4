using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AV.Swiper.Complete
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start("ios=db208c03-d2d5-40f8-b52e-173c0c00ca4e;" +
                  "uwp={Your UWP App secret here};" +
                  "android=543bf89a-cdb5-45d9-8c18-f82cebdebda4",
                  typeof(Analytics), typeof(Crashes), typeof(Push));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
