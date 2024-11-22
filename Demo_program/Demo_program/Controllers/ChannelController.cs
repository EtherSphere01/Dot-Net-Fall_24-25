using Demo_program.DTOs;
using Demo_program.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_program.Controllers
{
    public class ChannelController : Controller
    {
        // GET: Channel
        DemoExamEntities db = new DemoExamEntities();


       public static ChannelDTO Convert(Channel c)
        {
           return new ChannelDTO
            {
               ChannelId = c.ChannelId,
               ChannelName = c.ChannelName,
               EstablishedYear = c.EstablishedYear,
               Country = c.Country,
               
           };
        }

        public static Channel Convert(ChannelDTO c)
        {
            return new Channel
            {
                ChannelId = c.ChannelId,
                ChannelName = c.ChannelName,
                EstablishedYear = c.EstablishedYear,
                Country = c.Country,
            }; 
        }

        public static List<ChannelDTO> Convert(List<Channel> c)
        {
            List<ChannelDTO> result = new List<ChannelDTO>();
            foreach (var item in c)
            {
                result.Add(Convert(item));
            }
            return result;
        }
       
        public ActionResult List()
        {
            var channels = db.Channels.ToList();
            Session["increase"] = "1";
            return View(Convert(channels));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Channel());
        }

        [HttpPost]
       public ActionResult Create(ChannelDTO channel)
        {
            db.Channels.Add(Convert(channel));
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var channel = db.Channels.Find(id);
            return View(Convert(channel));
        }

        [HttpPost]
        public ActionResult Edit(ChannelDTO channel)
        {
            var channel_find = db.Channels.Find(channel.ChannelId);

            channel_find.ChannelName = channel.ChannelName;
            channel_find.EstablishedYear = channel.EstablishedYear;
            channel_find.Country = channel.Country;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var channel = db.Channels.Find(id);
            var program_list = (from item in db.Programs
                                where item.ChannelId == id
                                select item).ToList();
            ViewBag.plist = program_list;
            
            TempData["cnt"] = null;
            Session["increase"] = "1";
            if (program_list.Count != 0)
            {
                TempData["msg"] = "You cant delete this channel because it has programs.";
            }
            return View(Convert(channel));
        }
        [HttpPost]
        public ActionResult Delete(ChannelDTO channel, string dcsn)
        {
            if(dcsn == "Yes")
            {
                var channel_find = db.Channels.Find(channel.ChannelId);
                var c_id = channel.ChannelId;
                var p  = (from item in db.Programs
                             where item.ChannelId == c_id
                             select item).ToList();
                if (p.Count != 0)
                {
                    TempData["msg"] = "You cant delete this channel because it has programs.";
                    ViewBag.plist = p;
                    TempData["cnt"] = Session["increase"];
                    return View(Convert(channel_find));
                }
                else
                {
                   db.Channels.Remove(channel_find);
                }
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            var channel = db.Channels.Find(id);
            var program_list = (from item in db.Programs
                                where item.ChannelId == id
                                select item).ToList();
            ViewBag.plist = program_list;
            return View(Convert(channel));
        }
    }
}