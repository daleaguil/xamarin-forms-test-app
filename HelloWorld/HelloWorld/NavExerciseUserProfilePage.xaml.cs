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
    public partial class NavExerciseUserProfilePage : ContentPage
    {
        private UserService _userService;
        public NavExerciseUserProfilePage(int userId)
        {
            _userService = new UserService();

            var user = _userService.GetUser(userId);

            BindingContext = user;

            InitializeComponent();
        }
    }
}