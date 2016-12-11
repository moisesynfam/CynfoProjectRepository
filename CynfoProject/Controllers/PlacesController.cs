using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CynfoProject.Models;
using System.Security.Claims;

namespace CynfoProject.Controllers
{
    public class PlacesController : Controller
    {
        private GeneralDBContext db = new GeneralDBContext();

        // GET: Places
        public ActionResult Index()
        {
            Claim sessionUsername = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name);
            string username = sessionUsername.Value;
            var userIdQuery = db.UserAccounts.Where(u => u.Username == username).Select(u => u.UserID);
            var userId = userIdQuery.ToList()[0];

            return View(db.Places.Where(u => u.UserID == userId).ToList());
        }

        // GET: Places/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: Places/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaceID,PlaceName,PlaceDescription,PlaceLogoURL,PlaceMajor,PlaceAddress,Placecontact")] Place place)
        {
            if (ModelState.IsValid)
            {
                Claim sessionUsername = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name);
                string username = sessionUsername.Value;
                var userIdQuery = db.UserAccounts.Where(u => u.Username == username).Select(u => u.UserID);
                var userId = userIdQuery.ToList()[0];
                place.UserID = userId;
                db.Places.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(place);
        }

        // GET: Places/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaceID,PlaceName,PlaceDescription,PlaceLogoURL,PlaceMajor,PlaceAddress,Placecontact")] Place place)
        {
            if (ModelState.IsValid)
            {
                Claim sessionUsername = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name);
                string username = sessionUsername.Value;
                var userIdQuery = db.UserAccounts.Where(u => u.Username == username).Select(u => u.UserID);
                var userId = userIdQuery.ToList()[0];
                place.UserID = userId;
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(place);
        }

        // GET: Places/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Place place = db.Places.Find(id);
            db.Places.Remove(place);
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
