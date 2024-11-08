using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FromCreation.Models
{
    public class StudentInfo
    {
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-z.-]+$", ErrorMessage = "Name must contain only alphabets, (.) and (-)")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "Id must follow XX-XXXXX-X where X is number")]
        public string Id { get; set; }

        [Required]
        [CustomDob(20)]
        public string Dob { get; set; }

        [Required]
        [CustomEmail]
        public string Email { get; set; }

    }
  
}