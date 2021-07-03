using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTask1.Models
{
    public class Award
    {
        public string id { get; set; }
        public string Title { get; set; }

        public Award(string id, string title)
        {
            this.id = id;
            Title = title;
        }
        public Award()
        {
        }

         public override string ToString()
        {
            return Title;
        }
    }
}