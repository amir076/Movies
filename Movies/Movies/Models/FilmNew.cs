using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class FilmNew
    {
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Дата премьеры")]
        [MaxLength(4, ErrorMessage = "Неправильная дата"), MinLength(4, ErrorMessage = "Неправильная дата")]
        public string Date { get; set; }

        [Display(Name = "Продюсер")]
        public string Producer { get; set; }
        [Display(Name = "Постер")]
        public string Poster { get; set; }
        public string Created { get; set; }
        [Display(Name = "Трейлер")]
        public string TrailerUrl { get; set; }
    }
}