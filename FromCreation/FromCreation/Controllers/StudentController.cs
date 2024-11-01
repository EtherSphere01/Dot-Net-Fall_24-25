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
        // GET: Student
        [HttpGet]
       public ActionResult Form()
        {
            return View(new StudentInfo());
        }

        [HttpPost]
        public ActionResult Form(StudentInfo student)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
           
            return View(student);
        }

    }
}