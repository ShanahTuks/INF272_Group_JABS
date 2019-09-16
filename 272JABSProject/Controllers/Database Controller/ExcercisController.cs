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
    public class ExcercisController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: Excercis
        public ActionResult Index()
        {
            return View(db.Excercises.ToList());
        }

        // GET: Excercis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excercis excercis = db.Excercises.Find(id);
            if (excercis == null)
            {
                return HttpNotFound();
            }
            return View(excercis);
        }

        // GET: Excercis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Excercis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExcerciseID,ExcericiseName,ExcerciseDescription")] Excercis excercis)
        {
            if (ModelState.IsValid)
            {
                db.Excercises.Add(excercis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(excercis);
        }

        // GET: Excercis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excercis excercis = db.Excercises.Find(id);
            if (excercis == null)
            {
                return HttpNotFound();
            }
            return View(excercis);
        }

        // POST: Excercis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExcerciseID,ExcericiseName,ExcerciseDescription")] Excercis excercis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excercis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(excercis);
        }

        // GET: Excercis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Excercis excercis = db.Excercises.Find(id);
            if (excercis == null)
            {
                return HttpNotFound();
            }
            return View(excercis);
        }

        // POST: Excercis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Excercis excercis = db.Excercises.Find(id);
            db.Excercises.Remove(excercis);
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
