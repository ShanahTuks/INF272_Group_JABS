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
    public class CondtionTypesController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: CondtionTypes
        public ActionResult Index()
        {
            return View(db.CondtionTypes.ToList());
        }

        // GET: CondtionTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondtionType condtionType = db.CondtionTypes.Find(id);
            if (condtionType == null)
            {
                return HttpNotFound();
            }
            return View(condtionType);
        }

        // GET: CondtionTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CondtionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConditionTypeID,CondtionName,Description")] CondtionType condtionType)
        {
            if (ModelState.IsValid)
            {
                db.CondtionTypes.Add(condtionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condtionType);
        }

        // GET: CondtionTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondtionType condtionType = db.CondtionTypes.Find(id);
            if (condtionType == null)
            {
                return HttpNotFound();
            }
            return View(condtionType);
        }

        // POST: CondtionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConditionTypeID,CondtionName,Description")] CondtionType condtionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condtionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condtionType);
        }

        // GET: CondtionTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondtionType condtionType = db.CondtionTypes.Find(id);
            if (condtionType == null)
            {
                return HttpNotFound();
            }
            return View(condtionType);
        }

        // POST: CondtionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CondtionType condtionType = db.CondtionTypes.Find(id);
            db.CondtionTypes.Remove(condtionType);
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
