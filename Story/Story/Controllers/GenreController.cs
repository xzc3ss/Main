using Story.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Story.Controllers
{
    public class GenreController : Controller
    {
        StorymoviesEntities8 db = new StorymoviesEntities8();

        public ActionResult Index()
        {
            var gen = (from i in db.Genres
                       select i).ToList();

            return View(gen);

        }


        public ActionResult Create()
        {

            return View();

        }


        //
        // POST: /Genre/Create
        [HttpPost]
        public ActionResult Create(Genre gen)
        {
            var newgen = new Genre();

            if (ModelState.IsValid)
            {
                newgen.Name = gen.Name;
                newgen.ID = (from i in db.Genres
                                  select i.ID).Max() + 1;

                db.Genres.Add(newgen);
                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(gen);

        }


        [HttpGet]
        public ActionResult Delete()
        {

            return View();

        }


        //
        // POST: /Movies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var genre = (from i in db.Genres
                         where i.ID == id
                         select i).SingleOrDefault();

            db.Genres.Remove(genre);
            db.SaveChanges();
            
            return RedirectToAction("Index");

        }

    }
}
