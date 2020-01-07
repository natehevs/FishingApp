using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FishingApp.Models;
using Microsoft.AspNet.Identity;

namespace FishingApp.Controllers
{
    public class LocationMarkersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LocationMarkers
        public ActionResult Index(string searchString)
        {
            //ViewData["CurrentFilter"] = seachString;
            //if(!String.IsNullOrEmpty(searchString))
            //{
            //    locationMarkers = locationMarkers.Where(s => s.Rating.Contains(searchString));
            //}
            List<LocationMarkers> locationMarkers = db.LocationMarkers.Include(l => l.Enthusiast).Include(l => l.TechniqueModel).ToList();
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
        public ActionResult Create([Bind(Include = "MarkerID,EnthusiastID,Species,DateTimeCaught,BaitUsed,RodUsed,ReelUsed,LineUsed,LakeName,TechniqueId,Latitude,Longitude,Rating")] LocationMarkers locationMarkers)
        {
            if (ModelState.IsValid)
            {
                var loggedInId = User.Identity.GetUserId();
                var loggedInEnthusiast = db.Enthusiasts.Where(e => e.ApplicationId == loggedInId).SingleOrDefault();
                locationMarkers.EnthusiastID = loggedInEnthusiast.EnthusiastID;
                db.LocationMarkers.Add(locationMarkers);
                db.SaveChanges();
                return RedirectToAction("Index", "LocationMarkers");
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

        public ActionResult Filter(string SelectByTechnique)
        {
            var locationMarkers = db.LocationMarkers.Where(d => d.TechniqueModel.Technique == SelectByTechnique).ToList();
            return View(locationMarkers);
        }
    }
}
