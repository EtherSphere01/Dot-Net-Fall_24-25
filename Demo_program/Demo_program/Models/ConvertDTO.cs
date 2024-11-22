using Demo_program.Controllers;
using Demo_program.DTOs;
using Demo_program.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_program.Models
{
    public class ConvertDTO
    {
        public static ChannelDTO Convert(Channel c)
        {
            return new ChannelDTO
            {
                ChannelId = c.ChannelId,
                ChannelName = c.ChannelName,
                EstablishedYear = c.EstablishedYear,
                Country = c.Country,
                Programs = c.Programs,

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

    }
}