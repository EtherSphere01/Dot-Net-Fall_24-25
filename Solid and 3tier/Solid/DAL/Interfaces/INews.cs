using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INews
    {
        string Create(News news);
        string Update(News news);
        string Delete(int Id);
        List<News> GetAll();
        News GetById(int id);

        List<News> NewsByTitle(string title);
        List<News> NewsByCategory(string category);
        List<News> NewsByDate(DateTime date);
        List<News> NewsByTitleAndDate(string title, DateTime date);
        List<News> NewsByCategoryAndDate(string category, DateTime date);



    }
}
