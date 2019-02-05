using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class FilmDetail
    {
        public int ID { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Дата премьеры")]
        public string Date { get; set; }
        [Display(Name = "Продюсер")]
        public string Producer { get; set; }
        [Display(Name = "Трейлер")]
        public string TrailerUrl { get; set; }
        public string Poster { get; set; }
        public bool AllowEdit { get; set; }
    }
}