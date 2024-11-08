using FromCreation.EF;
using FromCreation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FromCreation.Controllers
{
    public class StudentController : Controller
    {
        FormCreationEntities db = new FormCreationEntities();

        // GET: Student
        [HttpGet]
        public ActionResult Form()
        {
            return View(new StudentInfo());
        }

        [HttpPost]
        public ActionResult Form(StudentInfo student)
        {
            if (ModelState.IsValid)
            {

                db.Students.Add(new Student
                {
                    Name = student.Name,
                    Id = student.Id,
                    Email = student.Email,
                    Dob = student.Dob
                });
                db.SaveChanges();
                return RedirectToAction("Display","Student");

            }

            return View(student);
        }

        [HttpGet]
        public ActionResult Display()
        {
            var students = db.Students.ToList();
            return View(students);

        }

        public ActionResult Details(string id)
        {
            var data = db.Students.Find(id);
            if(data != null)
            {
                return View(data);
            }
            TempData["msg"] = "Student not found";
            return RedirectToAction("Display");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var data = db.Students.Find(id);
            if (data != null)
            {
                return View(data);
            }
            TempData["msg"] = "Student not found";
            return RedirectToAction("Display");
        }

        [HttpPost]
        public ActionResult Edit(StudentInfo student)
        {
              var obj = db.Students.Find(student.Id);
                obj.Name = student.Name;
                obj.Dob = student.Dob;
                db.SaveChanges();
               return RedirectToAction("Display");
        }
        /* [HttpGet]
         public ActionResult Delete(string id)
         {
             var data = db.Students.Find(id);
             if (data != null)
             {
                  db.Students.Remove(data);
                  db.SaveChanges();
                  return RedirectToAction("Display");



             }
             return RedirectToAction("Display");
         } */

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var data = db.Students.Find(id);
            if (data != null)
            {
                /* db.Students.Remove(data);
                 db.SaveChanges();
                 return RedirectToAction("Display");
                */
                return View(data);

            }
            return RedirectToAction("Display");
        }

        [HttpPost]
        public ActionResult Delete(StudentInfo s)
        {
            var data = db.Students.Find(s.Id);
            if (data != null)
            {
                 db.Students.Remove(data);
                 db.SaveChanges();
                 return RedirectToAction("Display");

            }
            return RedirectToAction("Display");
        }
    }
}