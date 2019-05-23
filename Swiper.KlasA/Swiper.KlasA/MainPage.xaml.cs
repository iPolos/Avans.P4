using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swiper.KlasA.Controls;
using Xamarin.Forms;

namespace Swiper.KlasA
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private int _likeCount;
        private int _denyCount;

        public MainPage()
        {
            InitializeComponent();
            AddInitialPhotos();
        }

        private void UpdateGui()
        {
            InsertPhoto();
            likeLabel.Text = _likeCount.ToString();
            denyLabel.Text = _denyCount.ToString();
        }

        private void Handle_OnLike(object sender, EventArgs e)
        {
            _likeCount++;
            UpdateGui();
        }

        private void Handle_OnDeny(object sender, EventArgs e)
        {
            _denyCount++;
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

            this.mainGrid.Children.Insert(0, photo);
        }
    }
}
