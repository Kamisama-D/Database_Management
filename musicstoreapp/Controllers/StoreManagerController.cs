using musicstoreapp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace musicstoreapp.Controllers
{
    public class StoreManagerController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        
        // GET: StoreManager
        public ActionResult Index()
        {
            //StringBuilder bul = new StringBuilder();
            //bul.Append("SELECT ");
            //bul.Append("[Title]");
            //bul.Append(",[Price]");
            //bul.Append(",[InventoryAmount]");
            //bul.Append("FROM[musicstore].[dbo].[Albums]");
            //var param = new List<SqlParameter>()
            //var aa = storeDB.Database.SqlQuery(bul.ToString(), param);
            var albums = storeDB.Albums.Include(a => a.Genre).Include(a => a.Artist);
            return View(albums.ToList());
        }

        // GET: StoreManager/Details/5
        public ActionResult Details(int id)
        {
            Album album = storeDB.Albums.Find(id);
            return View(album);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name");
            return View();
        }

        // POST: StoreManager/Create
        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                storeDB.Albums.Add(album);
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int id)
        {
            Album album = storeDB.Albums.Find(id);
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // POST: StoreManager/Edit/5
        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                storeDB.Entry(album).State = EntityState.Modified;
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int id)
        {
            Album album = storeDB.Albums.Find(id);
            return View(album);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = storeDB.Albums.Find(id);
            storeDB.Albums.Remove(album);
            storeDB.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {
            var albums = storeDB.Albums.Where(a => a.Title.Contains(searchString));
            return View("Index", albums.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            storeDB.Dispose();
            base.Dispose(disposing);
        }
    }
}
