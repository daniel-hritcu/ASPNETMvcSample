using Microsoft.Ajax.Utilities;
using MVC1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC1.Controllers
{
    public class StudentController : Controller
    {

        
        // GET: Student
        public ActionResult Index()
        {
            //MvcApplication.studentsList.Clear();

            //MvcApplication.studentsList.Add(new Models.Student { StudentId = 1, StudentName = "Dan", Age = 18 });
            //MvcApplication.studentsList.Add(new Models.Student { StudentId = 2, StudentName = "Calin", Age = 28 });

            return View(MvcApplication.studentsList);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            // TODO: Add details logic here

            //Returns to index if studentId not found
            try
            {
                Student foundStudent = GetStudentById(id) ?? throw new Exception();
                return View(foundStudent);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(MVC1.Models.Student student)
        {
            try
            {
                // TODO: Add insert logic here
                student.StudentId = ++ MvcApplication.globalStudentId;
                MvcApplication.studentsList.Add(student);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student foundStudent = GetStudentById(id) ?? new Student();
            return View(foundStudent);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                Student foundStudent = GetStudentById(id) ?? throw new Exception();

                //Update Name
                foundStudent.StudentName = collection["StudentName"];
                //Update Age
                foundStudent.Age = int.Parse(collection["Age"]);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student foundStudent = GetStudentById(id) ?? new Student();
            return View(foundStudent);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Student foundStudent = GetStudentById(id) ?? throw new Exception();
                MvcApplication.studentsList.Remove(foundStudent);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //Helper Functions
        internal Student GetStudentById(int id) {
            var x = MvcApplication.studentsList.FirstOrDefault(s => s.StudentId == id);
            return x;
        }
    }
}
