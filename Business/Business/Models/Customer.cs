using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string ItemPurchased { get; set; }
        public string EmployeeName { get; set; }
        public Employee Employee { get; set; }
    }
}