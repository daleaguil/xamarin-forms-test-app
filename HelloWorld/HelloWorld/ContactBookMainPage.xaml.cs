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
    public partial class ContactBookMainPage : ContentPage
    {
        private ObservableCollection<Contact> _contacts;
        public ContactBookMainPage()
        {
            InitializeComponent();

            _contacts = new ObservableCollection<Contact>
            {
                new Contact { Id = 1, FirstName = "Dale", LastName = "Aguil", Email = "test@test.test", Phone = "12345", IsBlocked = false },
                new Contact { Id = 2, FirstName = "Juan", LastName = "Dela Cruz", Email = "test@test.test", Phone = "12345", IsBlocked = false },
            };

            listView.ItemsSource = _contacts;
        }

        async private void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listView.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;

            listView.SelectedItem = null;

            var page = new ContactBookContactDetailPage(selectedContact);

            page.ContactUpdated += (source, contact) =>
            {
                selectedContact.Id = contact.Id;
                selectedContact.FirstName = contact.FirstName;
                selectedContact.LastName = contact.LastName;
                selectedContact.Phone = contact.Phone;
                selectedContact.Email = contact.Email;
                selectedContact.IsBlocked = contact.IsBlocked;
            };

            await Navigation.PushAsync(page);
        }

        async private void OnContactAdd(object sender, EventArgs e)
        {
            var page = new ContactBookContactDetailPage(new Contact());

            page.ContactAdded += (source, contact) =>
            {
                _contacts.Add(contact);
            };

            await Navigation.PushAsync(page);
        }

        async private void OnContactDelete(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;

            if (await DisplayAlert("Warning", $"Do you want to delete {contact.FullName}?", "Yes", "No"))
                _contacts.Remove(contact);
        }
    }
}