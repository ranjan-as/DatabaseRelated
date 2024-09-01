using DatabaseRelated.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseRelated.Controllers
{
    public class DegreeController : Controller
    {
        // GET: Degree
        


        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Degree> degree = db.Degrees.ToList();
            return View(degree);            
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Degree s)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            context.Degrees.Add(s);
            context.SaveChanges();
            return RedirectToAction("Index", "Degree");
        }



        public ActionResult Edit(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Degree degree = db.Degrees.Where(x => x.DegreeId == id).SingleOrDefault();
            return View(degree);
        }
        [HttpPost]
        public ActionResult Edit(Degree degree)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Degree st = db.Degrees.Where(x => x.DegreeId== degree.DegreeId).SingleOrDefault();
            st.DegreeName = degree.DegreeName;
            db.SaveChanges();
            return RedirectToAction("Index", "Degree");
        }

        public ActionResult Details(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Degree degree = db.Degrees.Where(x => x.DegreeId == id).SingleOrDefault();
            return View(degree);
        }

        public ActionResult Delete(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Degree degree = db.Degrees.Where(x => x.DegreeId == id).SingleOrDefault();
            db.Degrees.Remove(degree);
            db.SaveChanges();
            return RedirectToAction("Index", "Degree");
        }
    }
}