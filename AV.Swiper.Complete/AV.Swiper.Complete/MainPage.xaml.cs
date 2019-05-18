using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AV.Swiper.Complete.Controls;
using Xamarin.Forms;

namespace AV.Swiper.Complete
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private int _likeCount;
        private int _denyCount;

        public MainPage()
        {
            InitializeComponent();
            //MainGrid.Children.Add(new SwiperControl());
            AddInitialPhotos();
        }

        private void UpdateGui()
        {
            likeLabel.Text = _likeCount.ToString();
            denyLabel.Text = _denyCount.ToString();
        }

        private void Handle_OnLike(object sender, EventArgs e)
        {
            _likeCount++;
            InsertPhoto();
            UpdateGui();
        }

        private void Handle_OnDeny(object sender, EventArgs e)
        {
            _denyCount++;
            InsertPhoto();
            UpdateGui();
        }

        private void AddInitialPhotos()
        {
            for (int i = 0; i < 10; i++)
            {
                InsertPhoto();
            }
        }

        private void InsertPhoto()
        {
            var photo = new SwiperControl();
            photo.OnLike += Handle_OnLike;
            photo.OnDeny += Handle_OnDeny;

            this.MainGrid.Children.Insert(0, photo);
        }
    }
}
