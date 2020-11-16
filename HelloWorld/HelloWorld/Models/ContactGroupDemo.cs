using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    class ContactGroupDemo : List<ContactDemo>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }

        public ContactGroupDemo(string title, string shortTitle)
        {
            Title = title;
            ShortTitle = shortTitle;
        }
    }
}
