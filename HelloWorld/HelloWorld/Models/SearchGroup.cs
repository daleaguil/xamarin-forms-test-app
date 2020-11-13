using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    class SearchGroup : List<Search>
    {
        public string Title { get; set; }

        public SearchGroup(string title, IEnumerable<Search> searches = null) : base(searches)
        {
            Title = title;
        }
    }
}
