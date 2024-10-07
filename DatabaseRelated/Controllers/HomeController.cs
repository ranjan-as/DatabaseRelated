using DatabaseRelated.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseRelated.Controllers
{
    
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController()
        {
            db=new ApplicationDbContext();
        }

        [ActionName("index-page")]
        public ActionResult Index()
        {
            return View("Index");
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
            context.Entry(d).State = System.Data.Entity.EntityState.Unchanged;
            //s.Degree.DegreeId =did;
            s.Degree = d;
            context.Students.Add(s);
            context.SaveChanges();
            return RedirectToAction("Display", "Home");
        }

        /*public ActionResult Create(Student s, string DegreeName)
        {
            // Convert the DegreeName to DegreeId
            int did = Convert.ToInt32(DegreeName);

            // Retrieve the existing Degree object from the database
            Degree d = db.Degrees.Where(x => x.DegreeId == did).SingleOrDefault();
            context.Entry(d).State = System.Data.Entity.EntityState.Unchanged;

            // Assign the existing Degree object to the Student
            s.Degree = d;

            // Add the new Student to the context and save changes
            db.Students.Add(s);
            db.SaveChanges();

            return RedirectToAction("Display", "Home");
        }*/

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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Student student = db.Students.Where(x => x.RollNumber == id).SingleOrDefault();
            db.Students.Remove(student);
            db.SaveChanges();

            //var obj = db.Students.Include("Semeter").Where(x => x.RollNumber == id).ToList();

            return RedirectToAction("Display", "Home");
        }

        public List<Degree> ADO() {
            List<Degree> degreeList = new List<Degree>();
            string connectionString = @"Data Source=ASUS\SQLEXPRESS;Initial Catalog=abc;Integrated Security=True;Encrypt=False";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Degrees", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);            
            //var result= cmd.ExecuteReader();
            DataTable dt = new DataTable();
            ad.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var degree = new Degree {
                    DegreeId = Convert.ToInt32( dr["DegreeId"]),
                    DegreeName= dr["DegreeName"].ToString()
                };
                degreeList.Add(degree);
            }

            con.Close();

            return degreeList;
        }

        [HttpPost]
        public int InsertAdo(string degreename) //form name variable
        {
            string connectionString = @"Data Source=ASUS\SQLEXPRESS;Initial Catalog=abc;Integrated Security=True;Encrypt=False";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Degrees VALUES('"+degreename +"')", con);
            //SqlCommand cmd = new SqlCommand("INSERT INTO Degrees (DegreeName) VALUES (@DegreeName)", con); //To prevent SQL injection use parameterized query.
            int result = cmd.ExecuteNonQuery();           

            con.Close();
            if (result == 1)
            {
                return 201;
            }
            return 400;
        }
    }
}












