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

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var contactMethodsPage = new ContactMethodsPage();
            contactMethodsPage.ContactMethods.ItemSelected += ContactMethods_ItemSelected;

            Navigation.PushAsync(contactMethodsPage);
        }

        private void ContactMethods_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            contactMethod.Text = e.SelectedItem.ToString();
            Navigation.PopAsync();
        }
    }
}