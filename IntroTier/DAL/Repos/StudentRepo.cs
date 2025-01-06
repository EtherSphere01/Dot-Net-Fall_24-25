using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class StudentRepo
    {
       UMSContext db = new UMSContext();
       public StudentRepo()
        {
            db = new UMSContext();
        }
       public List<Student> ShowDetails()
        {
            return db.Students.ToList();
        }

        public void AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public void RemoveStudent(int id) {
            var data = db.Students.Find(id);
            db.Students.Remove(data);
            db.SaveChanges();
        }
    }
}
