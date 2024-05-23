using musicstoreapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace musicstoreapp.Controllers
{
    public class HomeController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

        // GET: Home
        public ActionResult Index()
        {
            var albums = GetTopSellingAlbums(5);
            return View(albums);
        }

        private List<Album> GetTopSellingAlbums(int count)
        {
            return storeDB.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {
            var albums = storeDB.Albums.Where(a => a.Title.Contains(searchString));
            return View("Index", albums.ToList());
        }
    }
}