using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IArticleFeature
    {
         List<Article> GetByTag(string tag);
         List<Article> GetByDate(DateTime Date);
         List<Article> GetByAuthor(string author);
        List<Article> GetByTitle(string title);
        List<Article> UpdateTag(int tagid);


    }
}
