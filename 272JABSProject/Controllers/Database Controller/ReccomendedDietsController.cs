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
    public class ReccomendedDietsController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: ReccomendedDiets
        public ActionResult Index()
        {
            var reccomendedDiets = db.ReccomendedDiets.Include(r => r.Diet).Include(r => r.User);
            return View(reccomendedDiets.ToList());
        }

        // GET: ReccomendedDiets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReccomendedDiet reccomendedDiet = db.ReccomendedDiets.Find(id);
            if (reccomendedDiet == null)
            {
                return HttpNotFound();
            }
            return View(reccomendedDiet);
        }

        // GET: ReccomendedDiets/Create
        public ActionResult Create()
        {
            ViewBag.DietID = new SelectList(db.Diets, "DietID", "DietName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: ReccomendedDiets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReccDietID,DietID,Amount,UserID")] ReccomendedDiet reccomendedDiet)
        {
            if (ModelState.IsValid)
            {
                db.ReccomendedDiets.Add(reccomendedDiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DietID = new SelectList(db.Diets, "DietID", "DietName", reccomendedDiet.DietID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", reccomendedDiet.UserID);
            return View(reccomendedDiet);
        }

        // GET: ReccomendedDiets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReccomendedDiet reccomendedDiet = db.ReccomendedDiets.Find(id);
            if (reccomendedDiet == null)
            {
                return HttpNotFound();
            }
            ViewBag.DietID = new SelectList(db.Diets, "DietID", "DietName", reccomendedDiet.DietID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", reccomendedDiet.UserID);
            return View(reccomendedDiet);
        }

        // POST: ReccomendedDiets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReccDietID,DietID,Amount,UserID")] ReccomendedDiet reccomendedDiet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reccomendedDiet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DietID = new SelectList(db.Diets, "DietID", "DietName", reccomendedDiet.DietID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", reccomendedDiet.UserID);
            return View(reccomendedDiet);
        }

        // GET: ReccomendedDiets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReccomendedDiet reccomendedDiet = db.ReccomendedDiets.Find(id);
            if (reccomendedDiet == null)
            {
                return HttpNotFound();
            }
            return View(reccomendedDiet);
        }

        // POST: ReccomendedDiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReccomendedDiet reccomendedDiet = db.ReccomendedDiets.Find(id);
            db.ReccomendedDiets.Remove(reccomendedDiet);
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
