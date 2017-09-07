using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity; 
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;
using System.IO;

namespace MusicStore.Controllers
{
    public class AlbumsController : Controller
    {
       
        private MusicStoreContext db = new MusicStoreContext();
        [Authorize()]
        // GET: Albums
        public ActionResult Index()
        {
            //var albums = db.Albums.Include(a => a.Artist);
            return View(db.Albums.ToList());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albums albums = new Albums();
            albums = db.Albums.Where(var => var.AlbumsID == id).FirstOrDefault();
            if (albums == null)
            {
                return HttpNotFound();
            }
            return View(albums);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "ArtistName");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase Image, [Bind(Include = "AlbumsID,ArtistID,SongsID,AlbumName,ReleaseDate")] Albums albums)
        {
             
            if (ModelState.IsValid)
            {
                if (Image.ContentLength > 0 && Image==null)
                {
                    string getImageFileName = Path.GetFileName(albums.PictureArt);
                    string getFilePath = Path.Combine(Server.MapPath("~/Photos/"), getImageFileName);

                    Image.SaveAs(getFilePath);
                }
                albums.PictureArt = Image.FileName;
                db.Albums.Add(albums);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "ArtistName", albums.ArtistID);
            return View(albums);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albums albums = db.Albums.Find(id);
            if (albums == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "ArtistName", albums.ArtistID);
            return View(albums);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase Image, [Bind(Include = "AlbumsID,ArtistID,SongsID,AlbumName,ReleaseDate")] Albums albums)
        {
            if (ModelState.IsValid)
            {
                var _model = db.Albums.Find(albums.AlbumsID);
                string oldFilePath = _model.PictureArt;
                if (Image!= null &&  Image.ContentLength > 0)
                {
                    string ImageFileName = Path.GetFileName(Image.FileName);
                    string FolderPath = Path.Combine(Server.MapPath("~/Photos/"), ImageFileName);
                    Image.SaveAs(FolderPath);
                    albums.PictureArt =  Image.FileName;
                    string filepath = Request.MapPath("~" + oldFilePath);
                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                }
                _model.PictureArt = albums.PictureArt;
                //db.Entry(albums).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "ArtistName", albums.ArtistID);
            return View(albums);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albums albums = db.Albums.Find(id);
            if (albums == null)
            {
                return HttpNotFound();
            }
            return View(albums);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Albums albums = db.Albums.Find(id);
            db.Albums.Remove(albums);
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
