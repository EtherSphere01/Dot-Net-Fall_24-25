﻿using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class NewsContext : DbContext
    {
        public DbSet<Student> Students{ get; set; }
    }
}
