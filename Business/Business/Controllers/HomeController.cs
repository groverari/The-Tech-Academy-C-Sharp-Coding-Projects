using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Business.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult AddCustomer(string CustomerName, string Item, string EmployeeName)
        {
            if(string.IsNullOrEmpty(CustomerName) || string.IsNullOrEmpty(Item) || string.IsNullOrEmpty(EmployeeName))
            {
                return View("Error");
            }
            else
            {
                using (var db = new BusinessModel())
                {
                    Customer customer = new Customer();
                    customer.Name = CustomerName;
                    customer.ItemPurchased = Item;
                    customer.EmployeeName = EmployeeName;
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    return View("Success");
                }
                
            }
        }
        public ActionResult AddEmployee(string firstName, string lastName, string position)
        {
            if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(position)){
                return View("Error");
            }
            else
            {
                using (var db = new BusinessModel())
                {
                    Employee emp = new Employee();
                    
                    emp.FirstName = firstName;
                    emp.LastName = lastName;
                    emp.Position = position;
                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return View("Success");
                }
            }
        }
        public ActionResult GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (var db = new BusinessModel())
            {
                customers = db.Customers.ToList();
            }
            return View("Customers", customers);
        }
    }


}