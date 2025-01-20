using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Inf
{
    public interface INewsInterface<CLASS,ID,CATEGORY,DATE>
    {
        List<CLASS> GetAll();
        CLASS GetById(ID i);
        CATEGORY Delete(ID Id);
        CATEGORY Update(CLASS news);
        CATEGORY Create(CLASS news);
        List<CLASS> NewsByCategory(CATEGORY category);
        List<CLASS> NewsByDate(DATE date);
        List<CLASS> NewsByTitle(CATEGORY title);
        List<CLASS> NewsByCategoryAndDate(CATEGORY category, DATE date);
        List<CLASS> NewsByTitleAndDate(CATEGORY title, DATE date);
    }
}
