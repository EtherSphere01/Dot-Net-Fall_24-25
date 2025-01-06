using MidExam.DTOs;
using MidExam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidExam.Controllers
{
    public class UserController : Controller
    {
        public static UserDTO Convert(User u)
        {
            return new UserDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Password = u.Password,
                Role = u.Role,
            };
        }

        public static User Convert(UserDTO u)
        {
            return new User
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Password = u.Password,
                Role = u.Role,
            };
        }

        public static List<UserDTO> Convert(List<User> u)
        {
            List<UserDTO> list = new List<UserDTO>();
            foreach (var item in u)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        // GET: User
        InventoryEntities1 db = new InventoryEntities1();
        [HttpGet]
        public ActionResult Create()
        {
           return View(new UserDTO());
        }

        [HttpPost]
        public ActionResult Create(UserDTO u)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(Convert(u));
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(u);
        }

    }
}