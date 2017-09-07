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
    
    public class ArtistsController : Controller
    {
        private MusicStoreContext db = new MusicStoreContext();
        
        // GET: Artists
        public ActionResult Index()
        {
            return View(db.Artists.ToList());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = new Artist();
            artist = db.Artists.Where(a => a.ArtistID == id).FirstOrDefault();
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase UploadImage, [Bind(Include = "ArtistID,ArtistName,Description")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                if (UploadImage.ContentLength > 0)
                {
                    string getFileName = Path.GetFileName(UploadImage.FileName);
                    string getFilePath = Path.Combine(Server.MapPath("~/Photos/"), getFileName);
                    UploadImage.SaveAs(getFilePath);
                }
                artist.ArtistImage = UploadImage.FileName;
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase UploadImage, [Bind(Include = "ArtistID,ArtistName,Description")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                var getid = db.Artists.Find(artist.ArtistID);
                var getOldFilePath = getid.ArtistImage;
                var old = getid.ArtistName;
                if (UploadImage!=null && UploadImage.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(UploadImage.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/Photos/"), fileName);
                    UploadImage.SaveAs(filePath);
                    artist.ArtistImage = UploadImage.FileName;
                    string file = Request.MapPath("~"+ getOldFilePath);
                    string oldfile = Request.MapPath("~" + old);
                    if (System.IO.File.Exists(file))
                    {
                        System.IO.File.Delete(file);
                    }

                    if (System.IO.File.Exists(oldfile))
                    {
                        System.IO.File.Delete(oldfile);
                    }
                }
                getid.ArtistImage = artist.ArtistImage;
                getid.ArtistName = artist.ArtistName;
                db.SaveChanges();
                 
                return RedirectToAction("Index");
            }
           
            return View(artist);
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
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
