using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DataModel.Entity;
using Movies.Models;

namespace Movies.Services
{
    public static class ServiceFilm
    {
       
        public static FilmNew Create(FilmNew filmNew)
        {
            var _db = new ContextDB();
            var entity = new Film()
            {
                Name = filmNew.Name,
                Date =filmNew.Date,
                Description = filmNew.Description,
                Poster = filmNew.Poster,
                Producer = filmNew.Producer,
                Created = filmNew.Created,
                TrailerUrl = filmNew.TrailerUrl
            };

            _db.Films.Add(entity);
            _db.SaveChanges();
            return filmNew;
        }

        public static bool AllowToUpdate(int filmId , string userName)
        {
            var _db = new ContextDB();
            var entity = _db.Films.Find(filmId); 
            return userName == entity.Created;
        }

        public static FilmDetail Update(FilmDetail filmDetail)
        {
            var _db = new ContextDB();
            var entity = _db.Films.Find(filmDetail.ID);

            entity.Date = filmDetail.Date;
            entity.Description = filmDetail.Description;
            entity.Producer = filmDetail.Producer;
            entity.Name = filmDetail.Name;
            entity.TrailerUrl = filmDetail.TrailerUrl;
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
            return filmDetail;
        }
        public static FilmDetail GetDetails(int filmID)
        {
            var _db = new ContextDB();
            var film = _db.Films.Find(filmID);

            var filmDetail = new FilmDetail()
            {
                ID = film.ID,
                Name = film.Name,
                Date = film.Date,
                Description = film.Description,
                Poster = film.Poster,
                Producer = film.Producer,
                TrailerUrl = film.TrailerUrl
            };

            return filmDetail;
        }
        public static IQueryable<FilmView> Get()
        {
            var _db = new ContextDB();
            var _films  =_db.Films.Select(p => new FilmView()
            {
                ID = p.ID,
                Date = p.Date,
                Name = p.Name,
                Producer = p.Producer
            });
            return _films;
        }

    }
}