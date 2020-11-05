using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
            InitializeComponent();

            //btn.ImageSource = Device.RuntimePlatform == Device.Android
            //    ? ImageSource.FromFile("clock.png")
            //    : ImageSource.FromFile("Images/clock.png");
        }
    }
}