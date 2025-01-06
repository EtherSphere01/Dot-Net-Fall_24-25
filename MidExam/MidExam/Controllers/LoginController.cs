using MidExam.Auth;
using MidExam.DTOs;
using MidExam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidExam.Controllers
{
  
    public class LoginController : Controller
    {
        // GET: Login
        InventoryEntities1 db = new InventoryEntities1();

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginDTO());
        }

        [HttpPost]
        public ActionResult Login(LoginDTO l)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(x => x.Email == l.Email && x.Password == l.Password).FirstOrDefault();
                if (user != null)
                {
                    Session["user"] = user;
                    return RedirectToAction("List", "Admin");
                }
                else
                {
                    TempData["msg"] = "Invalid Email or Password";
                }
            }
            return View(l);
        }


    }
}