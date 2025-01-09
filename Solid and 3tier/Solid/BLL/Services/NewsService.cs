using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NewsService
    {
        

        public List<NewsDTO> GetAll()
        {
            var repo = DataAccess.NewsDataAccess();
            var data = repo.GetAll();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var result = mapper.Map<List<NewsDTO>>(data);

            return result;
        }

        public NewsDTO GetById(int id)
        {
            var repo = DataAccess.NewsDataAccess();
            var data = repo.GetById(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var result = mapper.Map<NewsDTO>(data);

            return result;
        }

        public string Delete(int Id)
        {
            var repo = DataAccess.NewsDataAccess();
            return repo.Delete(Id);
        }

        public string Update(NewsDTO news)
        {
            var repo = DataAccess.NewsDataAccess();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewsDTO, News>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News>(news);

            return repo.Update(data);
        }

        public string Create(NewsDTO news)
        {
            //var date = DateTime.Now.Date;
            //news.Date = date;
            var repo = DataAccess.NewsDataAccess();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewsDTO, News>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<News>(news);

            return repo.Create(data);
        }

        public List<NewsDTO> NewsByCategory(string category)
        {
            var repo = DataAccess.NewsDataAccess();
            var data = repo.NewsByCategory(category);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var result = mapper.Map<List<NewsDTO>>(data);

            return result;
        }

        public List<NewsDTO> NewsByDate(DateTime date)
        {
            var repo = DataAccess.NewsDataAccess();
            var data = repo.NewsByDate(date);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var result = mapper.Map<List<NewsDTO>>(data);

            return result;
        }

        public List<NewsDTO> NewsByTitle(string title)
        {
            var repo = DataAccess.NewsDataAccess();
            var data = repo.NewsByTitle(title);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var result = mapper.Map<List<NewsDTO>>(data);

            return result;
        }

        public List<NewsDTO> NewsByCategoryAndDate(string category, DateTime date)
        {
            var repo = DataAccess.NewsDataAccess();
            var data = repo.NewsByCategoryAndDate(category, date);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var result = mapper.Map<List<NewsDTO>>(data);

            return result;
        }

        public List<NewsDTO> NewsByTitleAndDate(string title, DateTime date)
        {
            var repo = DataAccess.NewsDataAccess();
            var data = repo.NewsByTitleAndDate(title, date);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var result = mapper.Map<List<NewsDTO>>(data);

            return result;
        }
    }
}
