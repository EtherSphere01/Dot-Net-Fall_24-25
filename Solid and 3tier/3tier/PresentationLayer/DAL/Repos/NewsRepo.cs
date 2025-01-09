using DAL.EF.Context;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class NewsRepo
    {
        NewsContext db = new NewsContext();
        public NewsRepo() 
        { 
            db = new NewsContext();
        }

        public List<News> GetAll()
        {
            return db.News.ToList();
        }

        public News GetById(int id)
        {
            return db.News.Find(id);
        }

        public string Delete(int Id)
        {
            var data = db.News.Find(Id);
            if(data != null)
            {
                db.News.Remove(data);
                db.SaveChanges();
                return "Deleted Successfully";
            }
            else
            {
                return "Not Found!!";
            }
 
        }

        public string Update(News news)
        {
            var data = db.News.Find(news.Id);
            if (data != null)
            {
                data.Title = news.Title;
                data.Date = news.Date;
                data.Category = news.Category;
                db.SaveChanges();
                return "Updated Successfully";
            }
            else
            {
                return "Not Found!!";
            }
        }

        public string Create(News news)
        {
            db.News.Add(news);
            db.SaveChanges();
            return "Inserted Successfully";
        }

        public List<News> NewsByCategory(string category)
        {   
            var data = (from n in db.News
                        where n.Category.Contains(category)
                        select n).ToList();
            return data;
        }

        public List<News> NewsByDate(DateTime date)
        {
            var data = (from n in db.News
                        where n.Date == date
                        select n).ToList();
            return data;
        }

        public List<News> NewsByTitle(string title)
        {
            var data = (from n in db.News
                        where n.Title.Contains(title)
                        select n).ToList();
            return data;
        }

        public List<News> NewsByCategoryAndDate(string category, DateTime date)
        {
            var data = (from n in db.News
                        where n.Category.Contains(category) && n.Date == date
                        select n).ToList();
            return data;
        }
        public List<News> NewsByTitleAndDate(string title, DateTime date)
        {
            var data = (from n in db.News
                        where n.Title.Contains(title) && n.Date == date
                        select n).ToList();
            return data;
        }
    }
}
