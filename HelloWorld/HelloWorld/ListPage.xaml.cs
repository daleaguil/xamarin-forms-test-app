using HelloWorld.Models;
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
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();

            listView.ItemsSource = new List<ContactGroup>
            {
                new ContactGroup("D", "D")
                {
                    new Contact { Name="Dale", ImageUrl="http://lorempixel.com/100/100/people/1" }
                },
                new ContactGroup("J", "J")
                {
                    new Contact { Name="Juan", ImageUrl="http://lorempixel.com/100/100/people/2", Status="Hey, let's talk!" }
                }
            };
        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            DisplayAlert("Tapped", contact.Name, "OK");
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listView.SelectedItem = null;
            //var contact = e.SelectedItem as Contact;
            //DisplayAlert("Selected", contact.Name, "OK");
        }
    }
}