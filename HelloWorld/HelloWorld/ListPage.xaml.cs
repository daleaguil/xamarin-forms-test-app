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
        private ObservableCollection<ContactDemo> _contacts;

        ObservableCollection<ContactDemo> GetContacts(string searchText = null)
        {
            //This simulates consuming a remote service.
            var contacts = new ObservableCollection<ContactDemo>
            {
                new ContactDemo { Name="Dale", ImageUrl="http://lorempixel.com/100/100/people/1" },
                new ContactDemo { Name="Juan", ImageUrl="http://lorempixel.com/100/100/people/2", Status="Hey, let's talk!" }
            };

            if (String.IsNullOrWhiteSpace(searchText))
                return contacts;

            return new ObservableCollection<ContactDemo>(contacts.Where(c => c.Name.ToLower().StartsWith(searchText)));
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
            var contact = menuItem.CommandParameter as ContactDemo;

            DisplayAlert("Call", contact.Name, "OK");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as ContactDemo;
            _contacts.Remove(contact);
        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = GetContacts();

            listView.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetContacts(e.NewTextValue);
        }
    }
}