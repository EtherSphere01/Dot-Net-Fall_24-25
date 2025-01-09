using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace PresentationLayer.Controllers
{
    public class NewsController : ApiController
    {
        public NewsService service = new NewsService();

        [HttpGet]
        [Route("api/news/getall")]
        public HttpResponseMessage GetAll()
        {
            var data = service.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/news/getbyid/{id}")]
       public HttpResponseMessage GetById(int id)
        {
            var data = service.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpDelete]
        [Route("api/news/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = service.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPut]
        [Route("api/news/update/{id}")]
        public HttpResponseMessage Update(NewsDTO news, int id)
        {
            news.Id = id;
            var data = service.Update(news);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/news/create")]
        public HttpResponseMessage Create(NewsDTO news)
        {
            var data = service.Create(news);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/news/newsbycategory/{category}")]
        public HttpResponseMessage NewsByCategory(string category)
        {
            var data = service.NewsByCategory(category);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/news/newsbydate/{date}")]
        public HttpResponseMessage NewsByDate(DateTime date)
        {
            var data = service.NewsByDate(date);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/news/newsbytitle/{title}")]
        public HttpResponseMessage NewsByTitle(string title)
        {
            var data = service.NewsByTitle(title);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/news/newsbycategoryanddate/{category}/{date}")]
        public HttpResponseMessage NewsByCategoryAndDate(string category, DateTime date)
        {
            var data = service.NewsByCategoryAndDate(category, date);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/news/newsbytitleanddate/{title}/{date}")]
        public HttpResponseMessage NewsByTitleAndDate(string title, DateTime date)
        {
            var data = service.NewsByTitleAndDate(title, date);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }



    }
}
