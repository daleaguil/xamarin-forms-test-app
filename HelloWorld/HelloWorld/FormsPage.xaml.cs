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
        public class ContactMethod
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private IList<ContactMethod> _contactMethods;
        public FormsPage()
        {
            InitializeComponent();

            _contactMethods = GetContactMethods();

            foreach (var method in _contactMethods)
                contactMethod.Items.Add(method.Name);
        }

        private void contactMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var methodName = contactMethod.Items[contactMethod.SelectedIndex];
            var method = _contactMethods.Single(m => m.Name == methodName);

            DisplayAlert("Sending a message thru:", String.Format("{0}: {1}",method.Id, methodName), "OK");
        }

        private IList<ContactMethod> GetContactMethods()
        {
            return new List<ContactMethod>
            {
                new ContactMethod { Id = 1, Name = "SMS" },
                new ContactMethod { Id = 2, Name = "Email" },
            };
        }
    }
}