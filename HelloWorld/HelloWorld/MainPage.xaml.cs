using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async private void Alert_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Warning", "Are you sure?", "Yes", "No");

            if (response)
                DisplayAlert("Success!", "Your answer has been recorded.", "OK");
        }

        async private void ActionSheet_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayActionSheet("Options", "Cancel", "Delete", "Copy Text", "Send Email");

            DisplayAlert("Your response is:", response, "OK");
        }
    }
}
