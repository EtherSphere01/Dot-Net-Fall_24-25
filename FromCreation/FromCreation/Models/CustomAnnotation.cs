using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FromCreation.Models
{
    public class CustomDob : ValidationAttribute
    {
        private readonly int _dob;
        public CustomDob(int dob) : base("Age Must be greater than 20 years")
        {
            _dob = dob;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
                
            if(value != null)
            {
                DateTime date;
                if (DateTime.TryParse(value.ToString(), out date))
                {
                    if (date.AddYears(_dob) > DateTime.Now)
                    {
                        var errorMessage = FormatErrorMessage(base.ErrorMessage);
                        return new ValidationResult(errorMessage);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }


    public class CustomEmail : ValidationAttribute
    {
        private readonly string _iid;
        public CustomEmail() : base("Must be a valid email address")
        {
           
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null) 
            {
                StudentInfo student = (StudentInfo)validationContext.ObjectInstance;
                string _id = student.Id;
                string email = "";
                string value_email = value.ToString();
                int length = value_email.Length;

                for (int i = 0; i < length; i++) {
                    if (value_email[i] == '@')
                    {
                        break;
                    }
                    else
                    {
                        email += value_email[i];
                    }
                }

                if (email!=_id)
                {
                    var errorMessage ="Email does not match with student id";
                    return new ValidationResult(errorMessage);
                }
                else
                {
                    var complete_email = _id + "@student.aiub.edu";
                    if (complete_email != value_email)
                    {
                        var errorMessage = FormatErrorMessage(base.ErrorMessage);
                        return new ValidationResult(errorMessage);
                    }
                }
            }
            
            return ValidationResult.Success;
        }
    }
}