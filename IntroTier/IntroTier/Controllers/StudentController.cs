using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroTier.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("api/student/ShowDetails")]
        public HttpResponseMessage ShowDetails()
        {
            var service = new StudentService();
            var data = service.ShowDetails();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/student/AddStudent")]
        public HttpResponseMessage AddStudent(StudentDTO student)
        {
            var service = new StudentService();
            service.AddStudent(student);
            return Request.CreateResponse(HttpStatusCode.OK,"Student Added Successfully");
        }

        [HttpPost]
        [Route("api/student/RemoveStudent")]
        public HttpResponseMessage RemoveStudent(StudentDTO s)
        {
            var service = new StudentService();
            service.RemoveStudent(s.Id);
            return Request.CreateResponse(HttpStatusCode.OK, "Student Removed Successfully");
        }
    }
}
