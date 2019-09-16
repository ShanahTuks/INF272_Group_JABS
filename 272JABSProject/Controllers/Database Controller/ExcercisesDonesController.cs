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
    public class ExcercisesDonesController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: ExcercisesDones
        public ActionResult Index()
        {
            var excercisesDones = db.ExcercisesDones.Include(e => e.Excercis).Include(e => e.User);
            return View(excercisesDones.ToList());
        }

        // GET: ExcercisesDones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcercisesDone excercisesDone = db.ExcercisesDones.Find(id);
            if (excercisesDone == null)
            {
                return HttpNotFound();
            }
            return View(excercisesDone);
        }

        // GET: ExcercisesDones/Create
        public ActionResult Create()
        {
            ViewBag.ExcerciseID = new SelectList(db.Excercises, "ExcerciseID", "ExcericiseName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: ExcercisesDones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExcerciseDoneID,ExcerciseID,UserID,Measurement")] ExcercisesDone excercisesDone)
        {
            if (ModelState.IsValid)
            {
                db.ExcercisesDones.Add(excercisesDone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExcerciseID = new SelectList(db.Excercises, "ExcerciseID", "ExcericiseName", excercisesDone.ExcerciseID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", excercisesDone.UserID);
            return View(excercisesDone);
        }

        // GET: ExcercisesDones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcercisesDone excercisesDone = db.ExcercisesDones.Find(id);
            if (excercisesDone == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExcerciseID = new SelectList(db.Excercises, "ExcerciseID", "ExcericiseName", excercisesDone.ExcerciseID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", excercisesDone.UserID);
            return View(excercisesDone);
        }

        // POST: ExcercisesDones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExcerciseDoneID,ExcerciseID,UserID,Measurement")] ExcercisesDone excercisesDone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excercisesDone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExcerciseID = new SelectList(db.Excercises, "ExcerciseID", "ExcericiseName", excercisesDone.ExcerciseID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", excercisesDone.UserID);
            return View(excercisesDone);
        }

        // GET: ExcercisesDones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExcercisesDone excercisesDone = db.ExcercisesDones.Find(id);
            if (excercisesDone == null)
            {
                return HttpNotFound();
            }
            return View(excercisesDone);
        }

        // POST: ExcercisesDones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExcercisesDone excercisesDone = db.ExcercisesDones.Find(id);
            db.ExcercisesDones.Remove(excercisesDone);
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
