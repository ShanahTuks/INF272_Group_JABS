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
    public class UserConditionsController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: UserConditions
        public ActionResult Index()
        {
            var userConditions = db.UserConditions.Include(u => u.CondtionType).Include(u => u.User);
            return View(userConditions.ToList());
        }

        // GET: UserConditions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCondition userCondition = db.UserConditions.Find(id);
            if (userCondition == null)
            {
                return HttpNotFound();
            }
            return View(userCondition);
        }

        // GET: UserConditions/Create
        public ActionResult Create()
        {
            ViewBag.ConditionTypeID = new SelectList(db.CondtionTypes, "ConditionTypeID", "CondtionName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: UserConditions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserConditionID,ConditionTypeID,UserID")] UserCondition userCondition)
        {
            if (ModelState.IsValid)
            {
                db.UserConditions.Add(userCondition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConditionTypeID = new SelectList(db.CondtionTypes, "ConditionTypeID", "CondtionName", userCondition.ConditionTypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", userCondition.UserID);
            return View(userCondition);
        }

        // GET: UserConditions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCondition userCondition = db.UserConditions.Find(id);
            if (userCondition == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConditionTypeID = new SelectList(db.CondtionTypes, "ConditionTypeID", "CondtionName", userCondition.ConditionTypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", userCondition.UserID);
            return View(userCondition);
        }

        // POST: UserConditions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserConditionID,ConditionTypeID,UserID")] UserCondition userCondition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userCondition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConditionTypeID = new SelectList(db.CondtionTypes, "ConditionTypeID", "CondtionName", userCondition.ConditionTypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", userCondition.UserID);
            return View(userCondition);
        }

        // GET: UserConditions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCondition userCondition = db.UserConditions.Find(id);
            if (userCondition == null)
            {
                return HttpNotFound();
            }
            return View(userCondition);
        }

        // POST: UserConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserCondition userCondition = db.UserConditions.Find(id);
            db.UserConditions.Remove(userCondition);
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
