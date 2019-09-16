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
    public class ConversationsController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: Conversations
        public ActionResult Index()
        {
            var conversations = db.Conversations.Include(c => c.User).Include(c => c.User1);
            return View(conversations.ToList());
        }

        // GET: Conversations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conversation conversation = db.Conversations.Find(id);
            if (conversation == null)
            {
                return HttpNotFound();
            }
            return View(conversation);
        }

        // GET: Conversations/Create
        public ActionResult Create()
        {
            ViewBag.User1ID = new SelectList(db.Users, "UserID", "UserName");
            ViewBag.User2ID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: Conversations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConversationID,User1ID,User2ID,TimeStamp,Status")] Conversation conversation)
        {
            if (ModelState.IsValid)
            {
                db.Conversations.Add(conversation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User1ID = new SelectList(db.Users, "UserID", "UserName", conversation.User1ID);
            ViewBag.User2ID = new SelectList(db.Users, "UserID", "UserName", conversation.User2ID);
            return View(conversation);
        }

        // GET: Conversations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conversation conversation = db.Conversations.Find(id);
            if (conversation == null)
            {
                return HttpNotFound();
            }
            ViewBag.User1ID = new SelectList(db.Users, "UserID", "UserName", conversation.User1ID);
            ViewBag.User2ID = new SelectList(db.Users, "UserID", "UserName", conversation.User2ID);
            return View(conversation);
        }

        // POST: Conversations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConversationID,User1ID,User2ID,TimeStamp,Status")] Conversation conversation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conversation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User1ID = new SelectList(db.Users, "UserID", "UserName", conversation.User1ID);
            ViewBag.User2ID = new SelectList(db.Users, "UserID", "UserName", conversation.User2ID);
            return View(conversation);
        }

        // GET: Conversations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conversation conversation = db.Conversations.Find(id);
            if (conversation == null)
            {
                return HttpNotFound();
            }
            return View(conversation);
        }

        // POST: Conversations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Conversation conversation = db.Conversations.Find(id);
            db.Conversations.Remove(conversation);
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
