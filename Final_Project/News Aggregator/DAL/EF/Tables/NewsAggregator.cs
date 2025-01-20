using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class NewsAggregator
    {
        public int Id {  get; set; }

        [Required]
        public string Name { get; set; }

        //public static virtual List<Atricle> Articles

    }
}
