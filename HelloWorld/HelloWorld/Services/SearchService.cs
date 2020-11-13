using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld.Services
{
    class SearchService
    {
        private List<Search> _searches = new List<Search>
        {
            new Search 
            {
                Id = 1,
                Location = "Manila", 
                CheckIn = new DateTime(2020, 9, 1), 
                CheckOut = new DateTime(2020, 9, 8) 
            },
            new Search 
            {
                Id = 2,
                Location = "Cebu", 
                CheckIn = new DateTime(2020, 9, 9), 
                CheckOut = new DateTime(2020, 9, 18) 
            }
        };

        public IEnumerable<Search> GetRecentSearches(string filter = null)
        {
            if (String.IsNullOrWhiteSpace(filter))
                return _searches;

            return _searches.Where(s => s.Location.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase));
        }

        public void DeleteSearch(int searchId)
        {
            _searches.Remove(_searches.Single(s => s.Id == searchId));
        }
    }
}
