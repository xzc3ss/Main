using Story.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.EnterpriseServices;
using System.Web.Mvc;

namespace Story.Controllers
{
  public class MoviesController : Controller
  {
    StorymoviesEntities8 db = new StorymoviesEntities8();

    public ActionResult Index()
    {
      var model = (from i in db.Movies
                   select i).ToList();

      return View(model);

    }


    //
    // GET: /Movies/Details/5
    public ActionResult Details(int id)
    {

      var model = (from i in db.Movies
                   where i.ID == id
                   select i).SingleOrDefault();



      return View(model);

    }


    //
    // GET: /Movies/Create
    [HttpGet]
    public ActionResult Create()
    {
      var model = new Movie();

      List<Genre> list = new List<Genre>(from i in db.Genres
                                         select i);

      List<SelectListItem> lists = new List<SelectListItem>();
      var s = (from i in db.Genres select new { ID = i.ID, Name = i.Name }).ToList();
      foreach (var i in s)
      {
        lists.Add(new SelectListItem { Text = i.Name, Value = i.ID.ToString() });
      }
      ViewData["GenreID"] = lists;

      //ViewBag.Gen = list;

      return View(model);

    }


    //
    // POST: /Movies/Create
    [HttpPost]
    public ActionResult Create(Movie movie)
    {
      Movie newmovie = new Movie();

      List<SelectListItem> lists = new List<SelectListItem>();
      var s = (from i in db.Genres select new { ID = i.ID, Name = i.Name }).ToList();
      foreach (var i in s)
      {
        lists.Add(new SelectListItem { Text = i.Name, Value = i.ID.ToString() });
      }
      ViewData["GenreID"] = lists;

      //ViewBag.Gen = list;

      if (ModelState.IsValid)
      {
        newmovie.Name = movie.Name;
        newmovie.Rating = movie.Rating;
        newmovie.GenreID = movie.GenreID;
        newmovie.Description = movie.Description;
        newmovie.Director = movie.Director;
        newmovie.Date = movie.Date;
        newmovie.ID = (from i in db.Movies
                       select i.ID).Max() + 1;

        db.Movies.Add(newmovie);
        db.SaveChanges();

        return RedirectToAction("Index");

      }

      return View(movie);

    }


    //
    // GET: /Movies/Edit/5
    [HttpGet]
    public ActionResult Edit(int id)
    {
      var model = (from i in db.Movies
                   where i.ID == id
                   select i);
      List<Genre> list = new List<Genre>(from i in db.Genres
                                         select i);
      ViewBag.Gen = list;

      if (model == null)
      {
        return HttpNotFound();
      }

      return View(model.FirstOrDefault());

    }


    //
    // POST: /Movies/Edit/5
    [HttpPost]
    public ActionResult Edit(Movie movie)
    {
      List<Genre> list = new List<Genre>(from i in db.Genres
                                         select i);
      ViewBag.Gen = list;

      if (ModelState.IsValid)
      {
        var model = (from i in db.Movies
                     where i.ID == movie.ID
                     select i).Single();

        model.Name = movie.Name;
        model.Rating = movie.Rating;
        model.GenreID = movie.GenreID;
        model.Description = movie.Description;
        model.Director = movie.Director;
        model.Date = movie.Date;

        db.SaveChanges();

        return RedirectToAction("Index");

      }

      return View();

    }


    //
    // GET: /Movies/Delete/5
    public ActionResult Delete(int id)
    {
      var model = (from i in db.Movies
                   where i.ID == id
                   select i);

      return View(model.FirstOrDefault());

    }


    //
    // POST: /Movies/Delete/5
    [HttpPost]
    public ActionResult Delete(Movie movie)
    {
      var model = (from i in db.Movies
                   where i.ID == movie.ID
                   select i).Single();

      db.Movies.Remove(model);
      db.SaveChanges();

      return RedirectToAction("Index");

    }
  }
}