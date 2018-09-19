using Insurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Evaluate(string FirstName, string LastName, string EmailAddress, DateTime DateOfBirth, string CarYear, string CarMake, string CarModel, string DUI, string Tickets, string Coverage)
        {
            bool go = string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(EmailAddress) || !(int.TryParse(CarYear, out int Year)) || string.IsNullOrEmpty(CarMake) ||
                string.IsNullOrEmpty(CarModel) || string.IsNullOrEmpty(DUI) || string.IsNullOrEmpty(Tickets) || string.IsNullOrEmpty(Coverage);
            if(go)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (InsuranceEntities db = new InsuranceEntities())
                {
                    var quote = new Quote();
                    quote.FirstName = FirstName;
                    quote.LastName = LastName;
                    quote.EmailAddress = EmailAddress;
                    quote.DateOfBirth = DateOfBirth;
                    quote.CarYear = Convert.ToInt32(CarYear);
                    quote.CarMake = CarMake;
                    quote.CarModel = CarModel;
                    quote.DUI = !(DUI =="0");
                    quote.Tickets = Convert.ToInt32(Tickets);
                    quote.Coverage = Coverage;
                    quote.Price = Calculate.Calculator(DateOfBirth, Convert.ToInt32(CarYear), CarMake, CarModel, Convert.ToInt32(Tickets), !(DUI == "0"), Coverage);

                    db.Quotes.Add(quote);
                    db.SaveChanges();
                    return View("Success", quote.Price);
                }
                
            }
            

        }
    }
    
}
 