using FishingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FishingApp.Controllers
{
    public class RatingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RatingsCheckIns
        public ActionResult Index()
        {
            var ratings = db.RatingModel.Include(r => r.DarkSkyLocation).Include(r => r.Observer);
            return View();
        }

        // GET: Rating/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rating/Create
        public ActionResult Create()
        {
            ViewBag.Marker.ID = new SelectList(db.LocationMarkers, "MarkerID", "Name");
            ViewBag.EnthusiastID = new SelectList(db.Enthusiasts, "EnthusiastId", "FirstName");
            return View();
        }

        // POST: Rating/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Rating")] RatingModel ratingModel, Enthusiast enthusiast, LocationMarkers locationMarkers)
        {
            if (ModelState.IsValid)
            {
                RatingModel ratings = new RatingModel();
                ratings.MarkerID = locationMarkers.MarkerID;
                ratings.EnthusiastID = enthusiast.EnthusiastID;
                ratings.Rating = ratingModel.Rating;
                db.RatingModel.Add(ratings);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.LocationId = new SelectList(db.LocationMarkers, "MarkerID", ratingModel.MarkerID);
            ViewBag.UserId = new SelectList(db.Enthusiasts, "UserId", "FirstName", ratingModel.EnthusiastID);
            return View(ratingModel);
        }

        // GET: Rating/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rating/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rating/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rating/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
