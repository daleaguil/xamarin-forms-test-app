using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    public partial class App : Application
    {
        private const string TitleKey = "Title";
        private const string NotificationsEnabledKey = "NotificationsEnabled";
        public App()
        {
            InitializeComponent();

            MainPage = new RESTfulServicesPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public string Title 
        { 
            get
            {
                if (Properties.ContainsKey(TitleKey))
                    return Properties[TitleKey].ToString();

                return "";
            }
            set
            {
                Properties[TitleKey] = value;
            }
        }

        public bool NotificationsEnabled
        {
            get
            {
                if (Properties.ContainsKey(NotificationsEnabledKey))
                    return (bool)Properties[NotificationsEnabledKey];

                return false;
            }
            set
            {
                Properties[NotificationsEnabledKey] = value;
            }
        }
    }
}
