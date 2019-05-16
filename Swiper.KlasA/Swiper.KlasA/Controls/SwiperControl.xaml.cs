using System;
using System.Collections.Generic;
using Swiper.KlasA.Utils;
using Xamarin.Forms;

namespace Swiper.KlasA.Controls
{
    public partial class SwiperControl : ContentView
    {
        private readonly double _initialRotation;
        private static readonly Random _random = new Random();

        private const double DeadZone = 0.4d;
        private const double DecisionThreshold = 0.4d;

        private double _screenWidth = -1;

        public SwiperControl()
        {
            InitializeComponent();

            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            this.GestureRecognizers.Add(panGesture);

            _initialRotation = _random.Next(-10, 10);
            photo.RotateTo(_initialRotation, 100, Easing.SinOut);

            var picture = new Picture();
            descriptionLabel.Text = picture.Description;
            image.Source = new UriImageSource { Uri = picture.Uri };

            loadingLabel.SetBinding(IsVisibleProperty, "IsLoading");
            loadingLabel.BindingContext = image;
        }

        private void CalculatePanState(double panX)
        {
            var halfScreenWidth = _screenWidth / 2;
            var deadZoneEnd = DeadZone * halfScreenWidth;

            if (Math.Abs(panX) < deadZoneEnd)
            {
                return;
            }

            var passedDeadZone = panX < 0 ? panX + deadZoneEnd : panX - deadZoneEnd;

            var decisionZoneEnd = DecisionThreshold * halfScreenWidth;
            var opacity = passedDeadZone / decisionZoneEnd;

            opacity = Clamp(opacity, -1, 1);

            likeStackLayout.Opacity = -opacity;
            denyStackLayout.Opacity = opacity;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (Application.Current.MainPage == null)
            {
                return;
            }

            // same as parameter width?
            _screenWidth = Application.Current.MainPage.Width;
        }

        private static double Clamp(double value, double min, double max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    PanStarted();
                    break;
                case GestureStatus.Running:
                    PanRunning(e);
                    break;
                case GestureStatus.Completed:
                    PanCompleted();
                    break;
            }
        }

        private void PanCompleted()
        {
            photo.TranslateTo(0, 0, 250, Easing.SpringOut);
            photo.RotateTo(_initialRotation, 250, Easing.SpringOut);
            photo.ScaleTo(1, 250);
        }

        private void PanRunning(PanUpdatedEventArgs e)
        {
            photo.TranslationX = e.TotalX;
            photo.TranslationY = e.TotalY;
            photo.Rotation = _initialRotation + (photo.TranslationX);

            CalculatePanState(e.TotalX);
        }

        private void PanStarted()
        {
            photo.ScaleTo(1.1, 100);
        }
    }
}
