﻿using DatabaseRelated.Models;
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

        public ActionResult Delete(int id)
        {
            Student student = db.Students.Where(x => x.RollNumber == id).SingleOrDefault();
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Display", "Home");
        }

    }
}