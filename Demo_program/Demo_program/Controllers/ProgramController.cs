using Demo_program.DTOs;
using Demo_program.EF;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Demo_program.Models;

namespace Demo_program.Controllers
{
    public class ProgramController : Controller
    {
        // GET: Program
        DemoExamEntities db = new DemoExamEntities();

        [HttpGet]
        public ActionResult ProgramList()
        {
            //var Channel_list = db.Channels.ToList();
            //var temp = (from item in db.Channels
            //            where item.ChannelId == (int)5
            //            select item).ToList();

            var Program = db.Programs.ToList();
            ViewBag.program_list = null;
            ViewBag.Channel_list = ConvertDTO.Convert(db.Channels.ToList());
            return View(ViewBag.Channel_list);
        }

        [HttpPost]
        public ActionResult ProgramList(int id)
        {
            ViewBag.program_list = ConvertDTO.Convert((from item in db.Channels
                                where item.ChannelId == (int)id
                                select item).ToList());
            ViewBag.Channel_list = ConvertDTO.Convert(db.Channels.ToList());
            return View(ViewBag.program_list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.channels = ConvertDTO.Convert(db.Channels.ToList());
            return View(new Program());
        }
        [HttpPost]
        public ActionResult Create(ProgramDTO program)
        {
            db.Programs.Add(ConvertDTO.Convert(program));
            TempData["msg"] = "Program Added Successfully";
            db.SaveChanges();
            return RedirectToAction("ProgramList");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var program = db.Programs.Find(id);
            ViewBag.channels = ConvertDTO.Convert(db.Channels.ToList());
            ViewBag.Channel_name = db.Channels.Find(program.ChannelId);
            return View(ConvertDTO.Convert(program));
        }
        [HttpPost]
        public ActionResult Edit(ProgramDTO program)
        {
            var program_find = db.Programs.Find(program.ProgramId);
            program_find.ProgramName = program.ProgramName;
            program_find.TRPScore = program.TRPScore;
            program_find.AirTime = program.AirTime;
            program_find.ChannelId = program.ChannelId;
            TempData["msg"] = "Program Edit Successfully";
            db.SaveChanges();
            return RedirectToAction("ProgramList");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var program = db.Programs.Find(id);
            ViewBag.Channel_name = db.Channels.Find(program.ChannelId);
            return View(ConvertDTO.Convert(program));
        }
        [HttpPost]
        public ActionResult Delete(ProgramDTO program, string dcsn)
        {
            var program_find = db.Programs.Find(program.ProgramId);
            if (dcsn == "Yes")
            {
                db.Programs.Remove(program_find);
                TempData["msg"] = "Program Deleted Successfully";
                db.SaveChanges();
            }
            return RedirectToAction("ProgramList");
        }

        
    }
}