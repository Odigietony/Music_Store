using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class SongsController : Controller
    {
        private MusicStoreContext db = new MusicStoreContext();
       

        public ActionResult SongDetails(long songID)
        {
     
            return View();
        }
        // GET: Songs
        public ActionResult Index()
        {
            var songs = db.Songs.Include(s => s.Albums);
            return View(songs.ToList());
        }

        // GET: Songs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Songs songs = db.Songs.Find(id);
            if (songs == null)
            {
                return HttpNotFound();
            }
            return View(songs);
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            ViewBag.AlbumsID = new SelectList(db.Albums, "AlbumsID", "AlbumName");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SongsID,AlbumsID,SongName,Genre,ReleaseDate")] Songs songs)
        {
            if (ModelState.IsValid)
            {
                db.Songs.Add(songs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumsID = new SelectList(db.Albums, "AlbumsID", "AlbumName", songs.AlbumsID);
            return View(songs);
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Songs songs = db.Songs.Find(id);
            if (songs == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumsID = new SelectList(db.Albums, "AlbumsID", "AlbumName", songs.AlbumsID);
            return View(songs);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SongsID,AlbumsID,SongName,Genre,ReleaseDate")] Songs songs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(songs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumsID = new SelectList(db.Albums, "AlbumsID", "AlbumName", songs.AlbumsID);
            return View(songs);
        }

        // GET: Songs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Songs songs = db.Songs.Find(id);
            if (songs == null)
            {
                return HttpNotFound();
            }
            return View(songs);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Songs songs = db.Songs.Find(id);
            db.Songs.Remove(songs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
