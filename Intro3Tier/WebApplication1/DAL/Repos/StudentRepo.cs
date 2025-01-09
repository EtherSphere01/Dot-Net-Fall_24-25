using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class StudentRepo
    {
        NewsContext db;
        public StudentRepo() { 

           db = new NewsContext();  
        }
        public List<Student> GetStudent()
        {
            var data = db.Students.ToList();
            return data;
        }
    }
}
