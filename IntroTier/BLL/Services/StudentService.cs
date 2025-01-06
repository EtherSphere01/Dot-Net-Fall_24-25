using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public List<StudentDTO> ShowDetails()
        {
            var repo = new StudentRepo();
            var data = repo.ShowDetails();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<StudentDTO>>(data);

            return ret;
        }

        public void AddStudent(StudentDTO student)
        {
            var repo = new StudentRepo();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StudentDTO, Student>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<Student>(student);

            repo.AddStudent(ret);
        }

        public void RemoveStudent(int id)
        {
            var repo = new StudentRepo();
            repo.RemoveStudent(id);
        }
    }
}
