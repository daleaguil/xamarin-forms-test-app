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
    public partial class FormsPage : ContentPage
    {
        public FormsPage()
        {
            InitializeComponent();
        }

        private void switch_Toggled(object sender, ToggledEventArgs e)
        {
            //Hide/Unhide label
            //labelSwitch.IsVisible = e.Value;
        }

        private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            //Change label's text
            //labelSlider.Text = String.Format("{0:N0}", e.NewValue);
        }
    }
}