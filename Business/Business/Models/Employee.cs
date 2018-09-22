using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Business.Models
{
    public class Employee
    {
        [Key]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position  { get; set; }   


    }
}