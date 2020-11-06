using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageExercise : ContentPage
    {
        public int _imageId = 1;
        public ImageExercise()
        {
            InitializeComponent();

            LoadImage();
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            if (_imageId == 10)
                _imageId = 1;
            else
                _imageId++;

            LoadImage();
        }

        private void btnPrevious_Clicked(object sender, EventArgs e)
        {
            if (_imageId == 1)
                _imageId = 10;
            else
                _imageId--;

            LoadImage();
        }

        void LoadImage()
        {
            var imageSource = new UriImageSource { Uri = new Uri(String.Format("http://lorempixel.com/1920/1080/city/{0}/", _imageId)) };
            imageSource.CachingEnabled = false;
            image.Source = imageSource;
        }
    }
}