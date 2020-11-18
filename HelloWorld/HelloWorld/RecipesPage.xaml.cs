using SQLite;
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
    public class Recipe 
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes;
        public RecipesPage()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Recipe>();

            var recipes = await _connection.Table<Recipe>().ToListAsync();
            _recipes = new ObservableCollection<Recipe>(recipes);

            recipesListView.ItemsSource = _recipes;

            base.OnAppearing();
        }

        async private void OnUpdate(object sender, EventArgs e)
        {
            var recipe = _recipes[0];

            recipe.Name += "UPDATED";

            await _connection.UpdateAsync(recipe);
        }

        async private void OnDelete(object sender, EventArgs e)
        {
            var recipe = recipesListView.SelectedItem as Recipe;

            await _connection.DeleteAsync(recipe);

            _recipes.Remove(recipe);
        }

        async private void OnAdd(object sender, EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe " + DateTime.Now.Ticks };

            await _connection.InsertAsync(recipe);

            _recipes.Add(recipe);
        }
    }
}