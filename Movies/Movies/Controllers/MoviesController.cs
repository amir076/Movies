using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Movies.Services;

namespace Movies.Controllers
{

    public class MoviesController : Controller
    {
        private string CurrentUserName()
        {
            return this.User.Identity.Name;
        }

        // GET: Movies
        public ActionResult Index(int? page)
        {
            var films = ServiceFilm.Get();
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page != null ? Convert.ToInt32(page) : 1;
                  
            return View(films.OrderBy(p=>p.ID).ToPagedList(pageIndex,pageSize));
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {

           FilmDetail filmDetail = ServiceFilm.GetDetails(id);
           filmDetail.AllowEdit = Services.ServiceFilm.AllowToUpdate(id, CurrentUserName());
            return View(filmDetail);
        }
        
        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(FilmNew filmNew, HttpPostedFileBase file)
        {

            if (string.IsNullOrEmpty(CurrentUserName()))
            {
                ModelState.AddModelError(string.Empty, "Для этой операции требуется авторизация");
            }

            if (ModelState.IsValid)
            {
                string pic = null;

                if (file != null)
                {
                     pic = System.IO.Path.GetFileName(file.FileName);
                    pic = string.Concat(Guid.NewGuid(), pic);
                    string path = System.IO.Path.Combine(
                        Server.MapPath("~/Images/FilmsImg"), pic);
                    // file is uploaded
                    file.SaveAs(path);
                }

                filmNew.Created = CurrentUserName();
                filmNew.Poster = pic;
                ServiceFilm.Create(filmNew);
                return RedirectToAction("Index");
            }
            else
            {
                return View(filmNew);
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            FilmDetail filmDetail = ServiceFilm.GetDetails(id);
            return View(filmDetail);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FilmDetail firmDetail)
        {
            try
            {
                if (Services.ServiceFilm.AllowToUpdate(id, CurrentUserName()))
                {
                    Services.ServiceFilm.Update(firmDetail);
                    // TODO: Add update logic here
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "У вас нет разрешения!");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
