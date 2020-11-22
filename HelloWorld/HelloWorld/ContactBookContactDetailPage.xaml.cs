using HelloWorld.Models;
using SQLite;
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
    public partial class ContactBookContactDetailPage : ContentPage
    {
		private SQLiteAsyncConnection _connection;
		public EventHandler<Contact> ContactAdded;
        public EventHandler<Contact> ContactUpdated;
        public ContactBookContactDetailPage(Contact contact)
        {
			if (contact == null)
				throw new ArgumentNullException(nameof(contact));

			InitializeComponent();

			_connection = DependencyService.Get<ISQLiteDb>().GetConnection();

			BindingContext = new Contact
			{
				Id = contact.Id,
				FirstName = contact.FirstName,
				LastName = contact.LastName,
				Phone = contact.Phone,
				Email = contact.Email,
				IsBlocked = contact.IsBlocked
			};
		}

		async void OnSave(object sender, System.EventArgs e)
		{
			var contact = BindingContext as Contact;

			if (String.IsNullOrWhiteSpace(contact.FullName))
			{
				await DisplayAlert("Error", "Please enter the name.", "OK");
				return;
			}

			if (contact.Id == 0)
			{
				ContactAdded?.Invoke(this, contact);

				await _connection.InsertAsync(contact);
			}
			else
			{
				ContactUpdated?.Invoke(this, contact);

				await _connection.UpdateAsync(contact);
			}

			await Navigation.PopAsync();
		}
	}
}