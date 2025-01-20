using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ArticleService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleDTO>();
                cfg.CreateMap<ArticleDTO, Article>();
                cfg.CreateMap<Article, ArticleTagDTO>();
                cfg.CreateMap<ArticleTagDTO, Article>();
                cfg.CreateMap<Tag, TagDTO>();
                cfg.CreateMap<TagDTO, Tag>();

            });
            return new Mapper(config);
        }
        public string Create(ArticleDTO obj)
        {
            var repo = DataAccessFactory.ArticleData();
            obj.Date = DateTime.Now.Date;
            var value = repo.Create(GetMapper().Map<Article>(obj));
            if (value == true)
            {
                return "Article Created Successfully";
            }
            else
            {
                return "Article Creation Failed";
            }
        }

        public string Update(ArticleDTO obj)
        {
            var repo = DataAccessFactory.ArticleData();
            var value = repo.Update(GetMapper().Map<Article>(obj));
            if (value == true)
            {
                return "Article Updated Successfully";
            }
            else
            {
                return "Article Update Failed";
            }
        }

        public string Delete(int id)
        {
            var repo = DataAccessFactory.ArticleData();
            var value = repo.Delete(id);
            if (value == true)
            {
                return "Article Deleted Successfully";
            }
            else
            {
                return "Article Deletion Failed";
            }
        }

        public ArticleDTO Get(int id)
        {
            var repo = DataAccessFactory.ArticleData();
            return GetMapper().Map<ArticleDTO>(repo.Get(id));
        }

        public List<ArticleDTO> GetAll()
        {
            var repo = DataAccessFactory.ArticleData();
            return GetMapper().Map<List<ArticleDTO>>(repo.GetAll());
        }

        public List<ArticleDTO> GetByTag(string tag)
        {
            var repo = DataAccessFactory.ArticleFeature();
            return GetMapper().Map<List<ArticleDTO>>(repo.GetByTag(tag));
        }

        public List<ArticleDTO> GetByAuthor(string author)
        {
            var repo = DataAccessFactory.ArticleFeature();
            return GetMapper().Map<List<ArticleDTO>>(repo.GetByAuthor(author));
        }

        public List<ArticleDTO> GetByDate(DateTime date)
        {
            var repo = DataAccessFactory.ArticleFeature();
            return GetMapper().Map<List<ArticleDTO>>(repo.GetByDate(date));
        }

    }
}
