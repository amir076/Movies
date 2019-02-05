using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class FilmView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Producer { get; set; }
    }
}