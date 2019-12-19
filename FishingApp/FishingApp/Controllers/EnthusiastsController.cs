using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FishingApp.Models;

namespace FishingApp.Controllers
{
    public class EnthusiastsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Enthusiasts
        public ActionResult Index()
        {
            return View(db.Enthusiasts.ToList());
        }

        // GET: Enthusiasts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enthusiast enthusiast = db.Enthusiasts.Find(id);
            if (enthusiast == null)
            {
                return HttpNotFound();
            }
            return View(enthusiast);
        }

        // GET: Enthusiasts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enthusiasts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnthusiastID,Username,Address,City,State,Zipcode")] Enthusiast enthusiast)
        {
            if (ModelState.IsValid)
            {
                db.Enthusiasts.Add(enthusiast);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enthusiast);
        }

        // GET: Enthusiasts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enthusiast enthusiast = db.Enthusiasts.Find(id);
            if (enthusiast == null)
            {
                return HttpNotFound();
            }
            return View(enthusiast);
        }

        // POST: Enthusiasts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnthusiastID,Username,Address,City,State,Zipcode")] Enthusiast enthusiast)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enthusiast).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enthusiast);
        }

        // GET: Enthusiasts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enthusiast enthusiast = db.Enthusiasts.Find(id);
            if (enthusiast == null)
            {
                return HttpNotFound();
            }
            return View(enthusiast);
        }

        // POST: Enthusiasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enthusiast enthusiast = db.Enthusiasts.Find(id);
            db.Enthusiasts.Remove(enthusiast);
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
