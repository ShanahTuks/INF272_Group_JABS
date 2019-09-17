using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _272JABSProject.Models;

namespace _272JABSProject.Controllers
{
    public class FitnessController : Controller
    {

        private FitnessEntities db = new FitnessEntities();

        // GET: Fitness
        public ActionResult Index()
        {
            return View();
        }

        //<<<<<<< HEAD
        //<<<<<<< HEAD
        //<<<<<<< HEAD
        public ActionResult UserProfile()
        {
            return View();
        }
        //<<<<<<< HEAD
        //=======

        public ActionResult FoodAnalysis()
        {
            return View();
        }
        //>>>>>>> Jackie'sBranch
        //=======
        public ActionResult ActivityInput()
        {
            return View();
        }

        public ActionResult FoodInput()
        {
            return View();
        }
        //>>>>>>> brendensbranch
        //=======

        public ActionResult ActivityAnalysis()
        {
            return View();
        }
        //>>>>>>> ShanahsBranch
        //=======
        public ActionResult LogInPage()
        {

            return View();
        }
        public ActionResult SignUpPage()
        {
            ViewBag.UserTypeID = new SelectList(db.UserTypes, "UserTypeID", "UserTypeName");
            return View();
        }
        //>>>>>>> Amo'sBranch
    }
}