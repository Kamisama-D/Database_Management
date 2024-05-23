using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using musicstoreapp.Models;

namespace musicstoreapp.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        //起始页
        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();

            return this.View(genres);
        }

        //浏览
        public ActionResult Browse(string genre)
        {
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);

            return this.View(genreModel);
        }

        //明细
        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.Find(id);
            return View(album);
        }

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genres.ToList();
            return PartialView(genres);
        }
    }
}