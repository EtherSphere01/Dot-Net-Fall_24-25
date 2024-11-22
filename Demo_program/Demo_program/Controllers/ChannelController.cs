using Demo_program.DTOs;
using Demo_program.EF;
using Demo_program.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_program.Controllers
{
    public class ChannelController : Controller
    {
        // GET: Channel
        DemoExamEntities db = new DemoExamEntities();

       
        public ActionResult List()
        {
            var channels = db.Channels.ToList();
            Session["increase"] = "1";
            return View(ConvertDTO.Convert(channels));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Channel());
        }

        [HttpPost]
       public ActionResult Create(ChannelDTO channel)
        {
            if (ModelState.IsValid)
            {
                db.Channels.Add(ConvertDTO.Convert(channel));
                TempData["msg"] = "Channel Added Successfully";
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(channel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var channel = db.Channels.Find(id);
            return View(ConvertDTO.Convert(channel));
        }

        [HttpPost]
        public ActionResult Edit(ChannelDTO channel)
        {
            if (ModelState.IsValid)
            {
                var channel_find = db.Channels.Find(channel.ChannelId);

                channel_find.ChannelName = channel.ChannelName;
                channel_find.EstablishedYear = channel.EstablishedYear;
                channel_find.Country = channel.Country;
                TempData["msg"] = "Channel Edit Successfully";
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(channel);
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
            return View(ConvertDTO.Convert(channel));
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
                    return View(ConvertDTO.Convert(channel_find));
                }
                else
                {
                   db.Channels.Remove(channel_find);
                    TempData["msg"] = "Channel Delete Successfully";
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
            return View(ConvertDTO.Convert(channel));
        }
    }
}