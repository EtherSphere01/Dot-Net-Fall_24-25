using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class StudentController : ApiController
    {
        StudentService service = new StudentService();

        [HttpGet]
        [Route("api/student/getstudent")]
        public HttpResponseMessage GetStudent()
        {
            var data = service.GetStudent();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
