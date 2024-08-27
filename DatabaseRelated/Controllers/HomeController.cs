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
            List<Degree> degree= db.Degrees.OrderBy(x=>x.DegreeName).ToList();
            List<SelectListItem> lst= new List<SelectListItem>();
            foreach (var item in degree)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = item.DegreeName;
                selectListItem.Value = item.DegreeId.ToString();
                lst.Add(selectListItem);
            }
            TempData["drop"]=lst;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s, string DegreeName) {
            ApplicationDbContext context = new ApplicationDbContext();
            int did = Convert.ToInt32(DegreeName);
            Degree d= db.Degrees.Where(x=>x.DegreeId == did).SingleOrDefault();
            s.Degree = d;
            context.Students.Add(s);
            context.SaveChanges();
            return RedirectToAction("Display", "Home");
        }

        public ActionResult Display()
        {
            List<Student> student=db.Students.ToList();
            return View(student);
        }

        public ActionResult Edit(int id) {
            Student student = db.Students.Where(x=>x.RollNumber==id).SingleOrDefault();
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            Student st = db.Students.Where(x => x.RollNumber == student.RollNumber).SingleOrDefault();
            st.Name = student.Name;
            st.FName = student.FName;
            db.SaveChanges();
            return RedirectToAction("Display","Home");
        }

        public ActionResult Details(int id)
        {
            Student student = db.Students.Where(x => x.RollNumber == id).SingleOrDefault();
            return View(student);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Student student = db.Students.Where(x => x.RollNumber == id).SingleOrDefault();
            db.Students.Remove(student);
            db.SaveChanges();

            //var obj = db.Students.Include("Semeter").Where(x => x.RollNumber == id).ToList();

            return RedirectToAction("Display", "Home");
        }

    }
}