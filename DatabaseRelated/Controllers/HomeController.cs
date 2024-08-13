using DatabaseRelated.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseRelated.Controllers
{
    
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController()
        {
            db=new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s) {
            ApplicationDbContext context = new ApplicationDbContext();
            context.Students.Add(s);
            context.SaveChanges();
            return View();
        }

        public IEnumerable<Student> Display()
        {
            List<Student> student=db.Students.ToList();
            return student;
        }

    }
}