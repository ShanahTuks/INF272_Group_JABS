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
    public class ReccomendedExcercisesController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: ReccomendedExcercises
        public ActionResult Index()
        {
            var reccomendedExcercises = db.ReccomendedExcercises.Include(r => r.Excercis).Include(r => r.User);
            return View(reccomendedExcercises.ToList());
        }

        // GET: ReccomendedExcercises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReccomendedExcercise reccomendedExcercise = db.ReccomendedExcercises.Find(id);
            if (reccomendedExcercise == null)
            {
                return HttpNotFound();
            }
            return View(reccomendedExcercise);
        }

        // GET: ReccomendedExcercises/Create
        public ActionResult Create()
        {
            ViewBag.ExcerciseID = new SelectList(db.Excercises, "ExcerciseID", "ExcericiseName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: ReccomendedExcercises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReccExcerciseID,ExcerciseID,UserID")] ReccomendedExcercise reccomendedExcercise)
        {
            if (ModelState.IsValid)
            {
                db.ReccomendedExcercises.Add(reccomendedExcercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExcerciseID = new SelectList(db.Excercises, "ExcerciseID", "ExcericiseName", reccomendedExcercise.ExcerciseID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", reccomendedExcercise.UserID);
            return View(reccomendedExcercise);
        }

        // GET: ReccomendedExcercises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReccomendedExcercise reccomendedExcercise = db.ReccomendedExcercises.Find(id);
            if (reccomendedExcercise == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExcerciseID = new SelectList(db.Excercises, "ExcerciseID", "ExcericiseName", reccomendedExcercise.ExcerciseID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", reccomendedExcercise.UserID);
            return View(reccomendedExcercise);
        }

        // POST: ReccomendedExcercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReccExcerciseID,ExcerciseID,UserID")] ReccomendedExcercise reccomendedExcercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reccomendedExcercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExcerciseID = new SelectList(db.Excercises, "ExcerciseID", "ExcericiseName", reccomendedExcercise.ExcerciseID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", reccomendedExcercise.UserID);
            return View(reccomendedExcercise);
        }

        // GET: ReccomendedExcercises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReccomendedExcercise reccomendedExcercise = db.ReccomendedExcercises.Find(id);
            if (reccomendedExcercise == null)
            {
                return HttpNotFound();
            }
            return View(reccomendedExcercise);
        }

        // POST: ReccomendedExcercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReccomendedExcercise reccomendedExcercise = db.ReccomendedExcercises.Find(id);
            db.ReccomendedExcercises.Remove(reccomendedExcercise);
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
