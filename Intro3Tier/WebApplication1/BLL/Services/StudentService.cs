using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
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
        StudentRepo repo = new StudentRepo();
        public List<StudentDTO> GetStudent()
        {
           var data = repo.GetStudent();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>();
            });
            var mapper = new Mapper(config);
            var result = mapper.Map<List<StudentDTO>>(data);
            return result;

        }
    }
}
