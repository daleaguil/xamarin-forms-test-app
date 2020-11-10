using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Contact> _contacts;

        ObservableCollection<Contact> GetContacts()
        {
            //This simulates consuming a remote service.
            return new ObservableCollection<Contact>
            {
                new Contact { Name="Dale", ImageUrl="http://lorempixel.com/100/100/people/1" },
                new Contact { Name="Juan", ImageUrl="http://lorempixel.com/100/100/people/2", Status="Hey, let's talk!" }
            };
        }
        public ListPage()
        {
            InitializeComponent();

            _contacts = GetContacts();

            listView.ItemsSource = _contacts;
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;

            DisplayAlert("Call", contact.Name, "OK");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            _contacts.Remove(contact);
        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = GetContacts();

            listView.EndRefresh();
        }
    }
}