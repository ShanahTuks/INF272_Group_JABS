using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _272JABSProject.Models;

namespace _272JABSProject.Controllers.Database_Controller
{
    public class AmountEatensController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: AmountEatens
        public ActionResult Index()
        {
            var amountEatens = db.AmountEatens.Include(a => a.Diet).Include(a => a.User);
            return View(amountEatens.ToList());
        }

        // GET: AmountEatens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AmountEaten amountEaten = db.AmountEatens.Find(id);
            if (amountEaten == null)
            {
                return HttpNotFound();
            }
            return View(amountEaten);
        }

        // GET: AmountEatens/Create
        public ActionResult Create()
        {
            ViewBag.DietID = new SelectList(db.Diets, "DietID", "DietName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: AmountEatens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AmountID,DietID,UserID,Amount")] AmountEaten amountEaten)
        {
            if (ModelState.IsValid)
            {
                db.AmountEatens.Add(amountEaten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DietID = new SelectList(db.Diets, "DietID", "DietName", amountEaten.DietID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", amountEaten.UserID);
            return View(amountEaten);
        }

        // GET: AmountEatens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AmountEaten amountEaten = db.AmountEatens.Find(id);
            if (amountEaten == null)
            {
                return HttpNotFound();
            }
            ViewBag.DietID = new SelectList(db.Diets, "DietID", "DietName", amountEaten.DietID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", amountEaten.UserID);
            return View(amountEaten);
        }

        // POST: AmountEatens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AmountID,DietID,UserID,Amount")] AmountEaten amountEaten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amountEaten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DietID = new SelectList(db.Diets, "DietID", "DietName", amountEaten.DietID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", amountEaten.UserID);
            return View(amountEaten);
        }

        // GET: AmountEatens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AmountEaten amountEaten = db.AmountEatens.Find(id);
            if (amountEaten == null)
            {
                return HttpNotFound();
            }
            return View(amountEaten);
        }

        // POST: AmountEatens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AmountEaten amountEaten = db.AmountEatens.Find(id);
            db.AmountEatens.Remove(amountEaten);
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
