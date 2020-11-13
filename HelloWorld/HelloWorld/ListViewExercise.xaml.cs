using HelloWorld.Models;
using HelloWorld.Services;
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
    public partial class ListViewExercise : ContentPage
    {
        private ObservableCollection<SearchGroup> _searchGroups;
        private SearchService _searchService;

        public ListViewExercise()
        {
            _searchService = new SearchService();

            InitializeComponent();

            PopulateListView(_searchService.GetRecentSearches());
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            PopulateListView(_searchService.GetRecentSearches(e.NewTextValue));
        }

        private void PopulateListView(IEnumerable<Search> searches)
        {
            _searchGroups = new ObservableCollection<SearchGroup>
            {
                new SearchGroup ("Recent Searches", searches)
            };

            listView.ItemsSource = _searchGroups;
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var search = (sender as MenuItem).CommandParameter as Search;

            _searchGroups[0].Remove(search);

            _searchService.DeleteSearch(search.Id);
        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            PopulateListView(_searchService.GetRecentSearches(searchBar.Text));
            listView.EndRefresh();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var search = e.SelectedItem as Search;
            DisplayAlert("Selected", search.Location, "OK");
        }
    }
}