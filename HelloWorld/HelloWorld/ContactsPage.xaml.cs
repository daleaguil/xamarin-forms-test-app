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
    public partial class ContactsPage : MasterDetailPage
    {
        public ContactsPage()
        {
            InitializeComponent();

            listView.ItemsSource = new List<ContactDemo>
            {
                new ContactDemo { Name="Dale", ImageUrl="http://lorempixel.com/100/100/people/1" },
                new ContactDemo { Name="Juan", ImageUrl="http://lorempixel.com/100/100/people/2", Status="Hey, let's talk!" }
            };
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contact = e.SelectedItem as ContactDemo;
            Detail = new NavigationPage(new ContactDetailPage(contact));
            IsPresented = false;
        }
    }
}