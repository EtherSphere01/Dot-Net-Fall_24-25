using Demo_program.DTOs;
using Demo_program.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace Demo_program.Controllers
{
    public class ProgramController : Controller
    {
        // GET: Program
        DemoExamEntities db = new DemoExamEntities();


        public static ProgramDTO Convert(Program p)
        {
            return new ProgramDTO
            {
                ProgramId = p.ProgramId,
                ProgramName = p.ProgramName,
                TRPScore = p.TRPScore,
                AirTime = p.AirTime,
                ChannelId = p.ChannelId,
            };
        }

        public static Program Convert(ProgramDTO p)
        {
            return new Program
            {
                ProgramId = p.ProgramId,
                ProgramName = p.ProgramName,
                TRPScore = p.TRPScore,
                AirTime = p.AirTime,
                ChannelId = p.ChannelId,
            };
        }

        public static List<ProgramDTO> Convert(List<Program> p)
        {
            List<ProgramDTO> result = new List<ProgramDTO>();
            foreach (var item in p)
            {
                result.Add(Convert(item));
            }
            return result;
        }

        public ActionResult ProgramList()
        {
            var Channels = db.Channels.ToList();
            List<Program> programs = new List<Program>();
            foreach(var item in Channels)
            {
                var program_list = (Convert(from item2 in db.Programs
                                            where item2.ChannelId == item.ChannelId
                                            select item2).ToList()));
                programs.Add(program_list);
            }

            return View(programs);
        }
    }
}