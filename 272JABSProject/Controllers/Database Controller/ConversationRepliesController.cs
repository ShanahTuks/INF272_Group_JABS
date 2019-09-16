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
    public class ConversationRepliesController : Controller
    {
        private FitnessEntities db = new FitnessEntities();

        // GET: ConversationReplies
        public ActionResult Index()
        {
            var conversationReplies = db.ConversationReplies.Include(c => c.Conversation).Include(c => c.User);
            return View(conversationReplies.ToList());
        }

        // GET: ConversationReplies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConversationReply conversationReply = db.ConversationReplies.Find(id);
            if (conversationReply == null)
            {
                return HttpNotFound();
            }
            return View(conversationReply);
        }

        // GET: ConversationReplies/Create
        public ActionResult Create()
        {
            ViewBag.ConversationID = new SelectList(db.Conversations, "ConversationID", "Status");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: ConversationReplies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CRID,Message,UserID,TimeStamp,Status,ConversationID")] ConversationReply conversationReply)
        {
            if (ModelState.IsValid)
            {
                db.ConversationReplies.Add(conversationReply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConversationID = new SelectList(db.Conversations, "ConversationID", "Status", conversationReply.ConversationID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", conversationReply.UserID);
            return View(conversationReply);
        }

        // GET: ConversationReplies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConversationReply conversationReply = db.ConversationReplies.Find(id);
            if (conversationReply == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConversationID = new SelectList(db.Conversations, "ConversationID", "Status", conversationReply.ConversationID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", conversationReply.UserID);
            return View(conversationReply);
        }

        // POST: ConversationReplies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CRID,Message,UserID,TimeStamp,Status,ConversationID")] ConversationReply conversationReply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conversationReply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConversationID = new SelectList(db.Conversations, "ConversationID", "Status", conversationReply.ConversationID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", conversationReply.UserID);
            return View(conversationReply);
        }

        // GET: ConversationReplies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConversationReply conversationReply = db.ConversationReplies.Find(id);
            if (conversationReply == null)
            {
                return HttpNotFound();
            }
            return View(conversationReply);
        }

        // POST: ConversationReplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConversationReply conversationReply = db.ConversationReplies.Find(id);
            db.ConversationReplies.Remove(conversationReply);
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
