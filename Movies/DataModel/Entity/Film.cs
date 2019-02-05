using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Entity
{
    public class Film
    {
        public int ID { get; set; }
        public string Name { get; set; }
       
        public string Description { get; set; }

        [MaxLength(4), MinLength(4)]
        public string Date { get; set; }
        public string Producer { get; set; }
        public string Poster { get; set; }
        public string TrailerUrl { get; set; }
        public string Created { get; set; }

    }
}
