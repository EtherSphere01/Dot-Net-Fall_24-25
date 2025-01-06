using MidExam.Auth;
using MidExam.DTOs;
using MidExam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MidExam.Controllers
{
    [Logged]
    public class AdminController : Controller
    {
        // GET: Admin
        InventoryEntities1 db = new InventoryEntities1();

        public static Product Convert(ProductDTO p)
        {
            return new Product
            {
                Id = p.Id,
                Name = p.Name,
                Quantity = p.Quantity,
                Reorder = p.Reorder,
            };
        }

        public static ProductDTO Convert(Product p)
        {
            return new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Quantity = p.Quantity,
                Reorder = p.Reorder,
            };
        }

        public static List<ProductDTO> Convert(List<Product> p)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            foreach (var item in p)
            {
                list.Add(Convert(item));
            }
            return list;
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProductDTO());
        }

        [HttpPost]
        public ActionResult Create(ProductDTO p)
        {
            if (ModelState.IsValid && p.Quantity != 0 && p.Reorder != 0)
            {
                db.Products.Add(Convert(p));
                db.SaveChanges();
                TempData["msg"] = "Product added successfully";
                return RedirectToAction("List");
            }
            return View(p);
        }

        public ActionResult List()
        {
            return View(Convert(db.Products.ToList()));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(Convert(db.Products.Find(id)));
        }

        [HttpPost]
        public ActionResult Edit(ProductDTO p)
        {

            if (ModelState.IsValid)
            {
                var editProduct = (from product in db.Products
                                   where product.Id == p.Id
                                   select product).FirstOrDefault();
                if (editProduct != null)
                {
                    editProduct.Name = p.Name;
                    editProduct.Quantity = p.Quantity;
                    editProduct.Reorder = p.Reorder;
                }
                db.SaveChanges();
                TempData["msg"] = "Product updated successfully";
                return RedirectToAction("List");
            }
            return View(p);

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(Convert(db.Products.Find(id)));
        }

        [HttpPost]
        public ActionResult Delete(int id, string dscn)
        {
            var deleteProduct = db.Products.Find(id);
            if (dscn == "Yes")
            {
                db.Products.Remove(deleteProduct);
                db.SaveChanges();
                TempData["msg"] = "Product deleted successfully";
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("List");
            }

        }

        public ActionResult Details(int id)
        {
            return View(Convert(db.Products.Find(id)));
        }
    }

}