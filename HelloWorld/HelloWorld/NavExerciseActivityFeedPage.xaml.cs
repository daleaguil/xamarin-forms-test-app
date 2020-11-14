using HelloWorld.Models;
using HelloWorld.Services;
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
    public partial class NavExerciseActivityFeedPage : ContentPage
    {
        private ActivityService _activityService;
        private IEnumerable<Activity> _activities;
        public NavExerciseActivityFeedPage()
        {
            _activityService = new ActivityService();
            _activities = _activityService.GetActivities();

            InitializeComponent();

            listView.ItemsSource = _activities;
        }

        async private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listView.SelectedItem == null)
                return;

            var user = e.SelectedItem as Activity;

            await Navigation.PushAsync(new NavExerciseUserProfilePage(user.UserId));
            listView.SelectedItem = null;
        }
    }
}