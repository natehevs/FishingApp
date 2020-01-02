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
    public class LocationMarkersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LocationMarkers
        public ActionResult Index()
        {
            var locationMarkers = db.LocationMarkers.Include(l => l.Enthusiast).Include(l => l.TechniqueModel);
            return View(locationMarkers.ToList());
        }

        // GET: LocationMarkers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationMarkers locationMarkers = db.LocationMarkers.Find(id);
            locationMarkers.Rating = AverageRating(locationMarkers);
            db.SaveChanges();
            if (locationMarkers == null)
            {
                return HttpNotFound();
            }
            return View(locationMarkers);
        }

        // GET: LocationMarkers/Create
        public ActionResult Create()
        {
            LocationMarkers locationMarkers = new LocationMarkers();
            locationMarkers.Techniques = new SelectList(db.TechniqueModels.ToList(), "TechniqueID", "Technique");
            return View(locationMarkers);
        }

        // POST: LocationMarkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarkerID,Species,DateTimeCaught,BaitUsed,GearID,LakeName,TechniqueID,Rating")] LocationMarkers locationMarkers)
        {
            if (ModelState.IsValid)
            {
                db.LocationMarkers.Add(locationMarkers);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(locationMarkers);
        }

        // GET: LocationMarkers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationMarkers locationMarkers = db.LocationMarkers.Find(id);
            if (locationMarkers == null)
            {
                return HttpNotFound();
            }
            return View(locationMarkers);
        }

        // POST: LocationMarkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarkerID,EnthusiastID,Species,DateTimeCaught,BaitUsed,GearID,LakeName,TechniqueID,Latitude,Longitude,AverageRating")] LocationMarkers locationMarkers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationMarkers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locationMarkers);
        }

        // GET: LocationMarkers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationMarkers locationMarkers = db.LocationMarkers.Find(id);
            if (locationMarkers == null)
            {
                return HttpNotFound();
            }
            return View(locationMarkers);
        }

        // POST: LocationMarkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationMarkers locationMarkers = db.LocationMarkers.Find(id);
            db.LocationMarkers.Remove(locationMarkers);
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

        public double AverageRating(LocationMarkers locationMarkers)
        {
            List<RatingController> ratingsObj = new List<RatingController>();
            List<string> ratings = new List<string>();
            List<int> integers = new List<int>();
            //ratingsObj = db.RatingController.Where(r => r.Rating > 0).Where(l => l.LocationId == LocationMarkers.LocationId).ToList();
            //foreach (RatingController rating in ratingsObj)
            //{
            //    Convert.ToInt32(rating.Rating);
            //    integers.Add(rating.Rating);
            //}
            double averageRating = integers.Average();
            return averageRating;
        }
    }
}
