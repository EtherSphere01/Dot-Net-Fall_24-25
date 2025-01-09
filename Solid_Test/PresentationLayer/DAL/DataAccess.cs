using DAL.EF.Tables;
using DAL.Inf;
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
        public static INewsInterface<News,int,string,DateTime> GetInterface() 
        { 
            return new NewsRepo();
        }
    }
}
