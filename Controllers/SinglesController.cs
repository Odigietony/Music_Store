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
    public class SinglesController : Controller
    {
        private MusicStoreContext db = new MusicStoreContext();

        // GET: Singles
        public ActionResult Index()
        {
            return View(db.Singles.ToList());
        }

        // GET: Singles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Singles singles = db.Singles.Find(id);
            if (singles == null)
            {
                return HttpNotFound();
            }
            return View(singles);
        }

        // GET: Singles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Singles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SinglesID,Title,Genre")] Singles singles)
        {
            if (ModelState.IsValid)
            {
                db.Singles.Add(singles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(singles);
        }

        // GET: Singles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Singles singles = db.Singles.Find(id);
            if (singles == null)
            {
                return HttpNotFound();
            }
            return View(singles);
        }

        // POST: Singles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SinglesID,Title,Genre")] Singles singles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(singles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(singles);
        }

        // GET: Singles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Singles singles = db.Singles.Find(id);
            if (singles == null)
            {
                return HttpNotFound();
            }
            return View(singles);
        }

        // POST: Singles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Singles singles = db.Singles.Find(id);
            db.Singles.Remove(singles);
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
