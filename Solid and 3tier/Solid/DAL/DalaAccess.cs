﻿using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
        public class DataAccess
        {
            public static INews NewsDataAccess()
            {
                return new NewsRepo();
             }
        }
    
}
